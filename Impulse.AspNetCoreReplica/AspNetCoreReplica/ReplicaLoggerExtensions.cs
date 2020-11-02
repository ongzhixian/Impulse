using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Logging;

namespace Impulse.Web.AspNetCoreReplica
{
    /// <summary>
    /// https://github.com/dotnet/aspnetcore/blob/0c2ee920a17fc11ecc6b5fe8febe330262a2d69b/src/Servers/Kestrel/Core/src/Internal/LoggerExtensions.cs
    /// </summary>
    internal static class ReplicaLoggerExtensions
    {
        // Category: DefaultHttpsProvider
        private static readonly Action<ILogger, string, string, Exception> _locatedDevelopmentCertificate =
            LoggerMessage.Define<string, string>(LogLevel.Debug, new EventId(0, nameof(LocatedDevelopmentCertificate)), "Using development certificate: {certificateSubjectName} (Thumbprint: {certificateThumbprint})");

        private static readonly Action<ILogger, Exception> _unableToLocateDevelopmentCertificate =
            LoggerMessage.Define(LogLevel.Debug, new EventId(1, nameof(UnableToLocateDevelopmentCertificate)), "Unable to locate an appropriate development https certificate.");

        private static readonly Action<ILogger, string, Exception> _failedToLocateDevelopmentCertificateFile =
            LoggerMessage.Define<string>(LogLevel.Debug, new EventId(2, nameof(FailedToLocateDevelopmentCertificateFile)), "Failed to locate the development https certificate at '{certificatePath}'.");

        private static readonly Action<ILogger, string, Exception> _failedToLoadDevelopmentCertificate =
            LoggerMessage.Define<string>(LogLevel.Debug, new EventId(3, nameof(FailedToLoadDevelopmentCertificate)), "Failed to load the development https certificate at '{certificatePath}'.");

        public static void LocatedDevelopmentCertificate(this ILogger logger, X509Certificate2 certificate) => _locatedDevelopmentCertificate(logger, certificate.Subject, certificate.Thumbprint, null);

        public static void UnableToLocateDevelopmentCertificate(this ILogger logger) => _unableToLocateDevelopmentCertificate(logger, null);

        public static void FailedToLocateDevelopmentCertificateFile(this ILogger logger, string certificatePath) => _failedToLocateDevelopmentCertificateFile(logger, certificatePath, null);

        public static void FailedToLoadDevelopmentCertificate(this ILogger logger, string certificatePath) => _failedToLoadDevelopmentCertificate(logger, certificatePath, null);
    }
}
