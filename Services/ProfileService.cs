using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Profile;
using backend.Dtos.File;
using backend.Entities;
using backend.Repositories.Interfaces;
using backend.Services.Interfaces;
using backend.Mappers;

using Microsoft.AspNetCore.Identity;

namespace backend.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUserRepository _userRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IAlumniProfileRepository _profileRepository;
        private readonly IFileRepository _fileRepository;
        

        public ProfileService(IUserRepository userRepository, IAlumniProfileRepository profileRepository, IStudentRepository studentRepository, IFileRepository fileRepository)
        {
            _userRepository = userRepository;
            _profileRepository = profileRepository;
            _studentRepository = studentRepository;
            _fileRepository = fileRepository;
        }

        public async Task<ProfileDto?> GetProfileAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            
            if(user == null)
            {
                return null;
            }

            if(user.StudentId == null)
            {
                return null;
            }

            
            var student = await _studentRepository.GetByIdAsync(user.StudentId.Value);

            if(student == null)
            {
                return null;
            }

            var profile = await _profileRepository.GetByUserIdAsync(userId);

            var profileDto = ProfileMapper.ToProfileDto(user, profile, student);

            profileDto.ImageUrl = $"/api/files/{profile?.ProfileGuid}";

            return profileDto;
            
        }


        // public async Task<ProfileDto?> UpdateProfileAsync(int userId, UpdateProfileDto dto)
        // {
        //     var user = await _userRepository.GetByIdAsync(userId);

        //     if(user == null)
        //     {
        //         return null;
        //     }

            
        //     var student = await _studentRepository.GetByIdAsync((int)user.StudentId!);
            

        //     var profile = await _profileRepository.GetByUserIdAsync(userId);

        //     if(profile == null)
        //     {
        //         return null;
        //     }

        //     user.Email = dto.Email!;
        //     user.PhoneNumber = dto.PhoneNumber;

        //     profile.Bio = dto.Bio;
        //     profile.ContactEmail = dto.ContactEmail;
        //     profile.ContactPhoneNumber = dto.ContactPhoneNumber;
        //     profile.AdditionalInformation = dto.AdditionalInformation;

        //     await _userRepository.UpdateAsync(user);
        //     await _profileRepository.UpdateAsync(profile);


            

        //     return ProfileMapper.ToProfileDto(user, profile, student!);
        // }



        public async Task<ProfileDto?> UpdateProfileAsync(int userId, UpdateProfileDto dto)
{
    var user = await _userRepository.GetByIdAsync(userId);

    if (user == null)
    {
        return null;
    }

    if (user.StudentId == null)
    {
        return null;
    }

    var student = await _studentRepository.GetByIdAsync(user.StudentId.Value);

    if (student == null)
    {
        return null;
    }

    var profile = await _profileRepository.GetByUserIdAsync(userId);

    if (profile == null)
    {
        return null;
    }

    // Update user
    user.Email = dto.Email!;
    user.PhoneNumber = dto.PhoneNumber;

    // Update profile
    profile.Bio = dto.Bio;
    profile.ContactEmail = dto.ContactEmail;
    profile.ContactPhoneNumber = dto.ContactPhoneNumber;
    profile.AdditionalInformation = dto.AdditionalInformation;

    await _userRepository.UpdateAsync(user);
    await _profileRepository.UpdateAsync(profile);

    // Upload profile picture (if one was provided)
    if (dto.ProfilePicture != null && dto.ProfilePicture.Length > 0)
{
    using var ms = new MemoryStream();
    await dto.ProfilePicture.CopyToAsync(ms);

    var extension = Path.GetExtension(dto.ProfilePicture.FileName)
        .TrimStart('.')
        .ToLower();

    int fileTypeId = extension switch
    {
        "jpg" => 1,
        "png" => 2,
        "jpeg" => 3,
        "svg" => 4,
        _ => throw new Exception("Unsupported image format.")
    };

    var addFileDto = new AddFileDto
    {
        ContentGuid = profile.ProfileGuid,
        EntityTypeId = 1,          // Profile
        FileName = dto.ProfilePicture.FileName,
        File = ms.ToArray(),
        FileTypeId = fileTypeId,
        UserId = userId,
        IsMainPic = true
    };

    var result = await _fileRepository.AddFileAsync(addFileDto);

    if (!result.IsAdded)
    {
        throw new Exception(result.Error);
    }
}

    return ProfileMapper.ToProfileDto(user, profile, student);
}


        
        public async Task<bool> UpdatePasswordAsync(int userId, UpdatePasswordDto dto)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if(user == null)
            {
                return false;
            }
            
            
            var passwordHasher = new PasswordHasher<User>();

            var result = passwordHasher.VerifyHashedPassword(user, user.HashedPassword, dto.OldPassword);

            if(result == PasswordVerificationResult.Failed)
            {
                return false;
            }

            user.HashedPassword = passwordHasher.HashPassword(user, dto.NewPassword);

            await _userRepository.UpdateAsync(user);


            return true;
        }
    }
}