namespace Utilities.Constants
{
    public readonly struct Codes
    {
        public const string DataValidationError = $"{Service.ServiceIdentifier}.0001";
        public const string EntityNotFound = $"{Service.ServiceIdentifier}.0002";
        public const string InvalidCount = $"{Service.ServiceIdentifier}.0003";
        public const string InvalidOffset = $"{Service.ServiceIdentifier}.0004";
        public const string UnhandledException = $"{Service.ServiceIdentifier}.0005";
        public const string InvalidDCP = $"{Service.ServiceIdentifier}.1006";

        public const string CustomerContactNo = $"{Service.ServiceIdentifier}.2001";
        public const string CustomerEmailId = $"{Service.ServiceIdentifier}.2002";
        public const string InvalidFreightCode = $"{Service.ServiceIdentifier}.1007";
    }


}
