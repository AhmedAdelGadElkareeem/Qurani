using System;
using System.Collections.Generic;
using System.Text;

namespace WytSky.Mobile.Maui.Skoola.Dtos
{
    public class AspNetUser : StBase
    {
        public string ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Picture { get; set; }
        public string Userurl { get; set; }
        public string Bio { get; set; }
        public string AvatarUrl { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string DeletedOn { get; set; }
        public Nullable<bool> EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string Discriminator { get; set; }
        public string ApplicationID { get; set; }
        public string LegacyPasswordHash { get; set; }
        public Nullable<bool> IsAnonymous { get; set; }
        public Nullable<DateTime> LastActivityDate { get; set; }
        public string PasswordQuestion { get; set; }
        public string PasswordAnswer { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public Nullable<bool> IsLockedOut { get; set; }
        public Nullable<DateTime> CreateDate { get; set; }
        public Nullable<DateTime> LastLoginDate { get; set; }
        public Nullable<DateTime> LastPasswordChangedDate { get; set; }
        public Nullable<DateTime> LastLockoutDate { get; set; }
        public Nullable<long> FailedPasswordAttemptCount { get; set; }
        public string FailedPasswordAttemptWindowStart { get; set; }
        public Nullable<long> FailedPasswordAnswerAttemptCount { get; set; }
        public string FailedPasswordAnswerAttemptWindowStart { get; set; }
        public string Comment { get; set; }
        public string ProfileDateofbirth { get; set; }
        public string ProfileCity { get; set; }
        public string ProfileUserstatsHeight { get; set; }
        public string ProfileUserstatsWeight { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<bool> PhoneNumberConfirmed { get; set; }
        public Nullable<bool> TwoFactorEnabled { get; set; }
        public string LockoutEndDateUtc { get; set; }
        public Nullable<bool> LockoutEnabled { get; set; }
        public Nullable<long> AccessFailedCount { get; set; }
        public string PictureFileName { get; set; }
        public string PictureContentType { get; set; }
        public string PictureLength { get; set; }
        public Nullable<DateTime> LastLockedOutDate { get; set; }
        public Nullable<DateTime> CreationDate { get; set; }
        public string LoweredUserName { get; set; }
        public string MobileAlias { get; set; }
        public string MobilePin { get; set; }
        public string LoweredEmail { get; set; }
        public Nullable<long> VerficationCode { get; set; }
        public Nullable<bool> Confirmed { get; set; }
        public string ResetPasswordCode { get; set; }
        public Nullable<long> UserTypeID { get; set; }
        public string NormalizedEmail { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string LockoutEnd { get; set; }
        public string NormalizedUserName { get; set; }
    }
}
