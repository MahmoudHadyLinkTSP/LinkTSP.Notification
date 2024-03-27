using System.Collections.Generic;
using VirtoCommerce.Platform.Core.Settings;

namespace LinkTSP.Notification.Core
{
    public static class ModuleConstants
    {
        public static class Security
        {
            public static class Permissions
            {
                public const string Access = "Notification:access";
                public const string Create = "Notification:create";
                public const string Read = "Notification:read";
                public const string Update = "Notification:update";
                public const string Delete = "Notification:delete";

                public static string[] AllPermissions { get; } =
                {
                    Access,
                    Create,
                    Read,
                    Update,
                    Delete,
                };
            }
        }

        public static class Settings
        {
            public static class General
            {
                public static SettingDescriptor NotificationEnabled { get; } = new SettingDescriptor
                {
                    Name = "Notification.NotificationEnabled",
                    GroupName = "Notification|General",
                    ValueType = SettingValueType.Boolean,
                    DefaultValue = false,
                };

                public static SettingDescriptor NotificationPassword { get; } = new SettingDescriptor
                {
                    Name = "Notification.NotificationPassword",
                    GroupName = "Notification|Advanced",
                    ValueType = SettingValueType.SecureString,
                    DefaultValue = "qwerty",
                };

                public static IEnumerable<SettingDescriptor> AllGeneralSettings
                {
                    get
                    {
                        yield return NotificationEnabled;
                        yield return NotificationPassword;
                    }
                }
            }

            public static IEnumerable<SettingDescriptor> AllSettings
            {
                get
                {
                    return General.AllGeneralSettings;
                }
            }
        }
    }
}
