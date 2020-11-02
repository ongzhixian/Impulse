﻿using System.Globalization;
using System.Reflection;
using System.Resources;

namespace Impulse.Web.AspNetCoreReplica
{
    internal static class ReplicaCoreStrings
    {
        private static readonly ResourceManager _resourceManager
            = new ResourceManager("Microsoft.AspNetCore.Server.Kestrel.Core.CoreStrings", typeof(ReplicaCoreStrings).GetTypeInfo().Assembly);

        /// <summary>
        /// Bad request.
        /// </summary>
        internal static string BadRequest
        {
            get => GetString("BadRequest");
        }

        /// <summary>
        /// Bad request.
        /// </summary>
        internal static string FormatBadRequest()
            => GetString("BadRequest");

        /// <summary>
        /// Bad chunk size data.
        /// </summary>
        internal static string BadRequest_BadChunkSizeData
        {
            get => GetString("BadRequest_BadChunkSizeData");
        }

        /// <summary>
        /// Bad chunk size data.
        /// </summary>
        internal static string FormatBadRequest_BadChunkSizeData()
            => GetString("BadRequest_BadChunkSizeData");

        /// <summary>
        /// Bad chunk suffix.
        /// </summary>
        internal static string BadRequest_BadChunkSuffix
        {
            get => GetString("BadRequest_BadChunkSuffix");
        }

        /// <summary>
        /// Bad chunk suffix.
        /// </summary>
        internal static string FormatBadRequest_BadChunkSuffix()
            => GetString("BadRequest_BadChunkSuffix");

        /// <summary>
        /// Chunked request incomplete.
        /// </summary>
        internal static string BadRequest_ChunkedRequestIncomplete
        {
            get => GetString("BadRequest_ChunkedRequestIncomplete");
        }

        /// <summary>
        /// Chunked request incomplete.
        /// </summary>
        internal static string FormatBadRequest_ChunkedRequestIncomplete()
            => GetString("BadRequest_ChunkedRequestIncomplete");

        /// <summary>
        /// The message body length cannot be determined because the final transfer coding was set to '{detail}' instead of 'chunked'.
        /// </summary>
        internal static string BadRequest_FinalTransferCodingNotChunked
        {
            get => GetString("BadRequest_FinalTransferCodingNotChunked");
        }

        /// <summary>
        /// The message body length cannot be determined because the final transfer coding was set to '{detail}' instead of 'chunked'.
        /// </summary>
        internal static string FormatBadRequest_FinalTransferCodingNotChunked(object detail)
            => string.Format(CultureInfo.CurrentCulture, GetString("BadRequest_FinalTransferCodingNotChunked", "detail"), detail);

        /// <summary>
        /// Request headers too long.
        /// </summary>
        internal static string BadRequest_HeadersExceedMaxTotalSize
        {
            get => GetString("BadRequest_HeadersExceedMaxTotalSize");
        }

        /// <summary>
        /// Request headers too long.
        /// </summary>
        internal static string FormatBadRequest_HeadersExceedMaxTotalSize()
            => GetString("BadRequest_HeadersExceedMaxTotalSize");

        /// <summary>
        /// Invalid characters in header name.
        /// </summary>
        internal static string BadRequest_InvalidCharactersInHeaderName
        {
            get => GetString("BadRequest_InvalidCharactersInHeaderName");
        }

        /// <summary>
        /// Invalid characters in header name.
        /// </summary>
        internal static string FormatBadRequest_InvalidCharactersInHeaderName()
            => GetString("BadRequest_InvalidCharactersInHeaderName");

        /// <summary>
        /// Invalid content length: {detail}
        /// </summary>
        internal static string BadRequest_InvalidContentLength_Detail
        {
            get => GetString("BadRequest_InvalidContentLength_Detail");
        }

        /// <summary>
        /// Invalid content length: {detail}
        /// </summary>
        internal static string FormatBadRequest_InvalidContentLength_Detail(object detail)
            => string.Format(CultureInfo.CurrentCulture, GetString("BadRequest_InvalidContentLength_Detail", "detail"), detail);

        /// <summary>
        /// Invalid Host header.
        /// </summary>
        internal static string BadRequest_InvalidHostHeader
        {
            get => GetString("BadRequest_InvalidHostHeader");
        }

        /// <summary>
        /// Invalid Host header.
        /// </summary>
        internal static string FormatBadRequest_InvalidHostHeader()
            => GetString("BadRequest_InvalidHostHeader");

        /// <summary>
        /// Invalid Host header: '{detail}'
        /// </summary>
        internal static string BadRequest_InvalidHostHeader_Detail
        {
            get => GetString("BadRequest_InvalidHostHeader_Detail");
        }

        /// <summary>
        /// Invalid Host header: '{detail}'
        /// </summary>
        internal static string FormatBadRequest_InvalidHostHeader_Detail(object detail)
            => string.Format(CultureInfo.CurrentCulture, GetString("BadRequest_InvalidHostHeader_Detail", "detail"), detail);

        /// <summary>
        /// Invalid request headers: missing final CRLF in header fields.
        /// </summary>
        internal static string BadRequest_InvalidRequestHeadersNoCRLF
        {
            get => GetString("BadRequest_InvalidRequestHeadersNoCRLF");
        }

        /// <summary>
        /// Invalid request headers: missing final CRLF in header fields.
        /// </summary>
        internal static string FormatBadRequest_InvalidRequestHeadersNoCRLF()
            => GetString("BadRequest_InvalidRequestHeadersNoCRLF");

        /// <summary>
        /// Invalid request header: '{detail}'
        /// </summary>
        internal static string BadRequest_InvalidRequestHeader_Detail
        {
            get => GetString("BadRequest_InvalidRequestHeader_Detail");
        }

        /// <summary>
        /// Invalid request header: '{detail}'
        /// </summary>
        internal static string FormatBadRequest_InvalidRequestHeader_Detail(object detail)
            => string.Format(CultureInfo.CurrentCulture, GetString("BadRequest_InvalidRequestHeader_Detail", "detail"), detail);

        /// <summary>
        /// Invalid request line.
        /// </summary>
        internal static string BadRequest_InvalidRequestLine
        {
            get => GetString("BadRequest_InvalidRequestLine");
        }

        /// <summary>
        /// Invalid request line.
        /// </summary>
        internal static string FormatBadRequest_InvalidRequestLine()
            => GetString("BadRequest_InvalidRequestLine");

        /// <summary>
        /// Invalid request line: '{detail}'
        /// </summary>
        internal static string BadRequest_InvalidRequestLine_Detail
        {
            get => GetString("BadRequest_InvalidRequestLine_Detail");
        }

        /// <summary>
        /// Invalid request line: '{detail}'
        /// </summary>
        internal static string FormatBadRequest_InvalidRequestLine_Detail(object detail)
            => string.Format(CultureInfo.CurrentCulture, GetString("BadRequest_InvalidRequestLine_Detail", "detail"), detail);

        /// <summary>
        /// Invalid request target: '{detail}'
        /// </summary>
        internal static string BadRequest_InvalidRequestTarget_Detail
        {
            get => GetString("BadRequest_InvalidRequestTarget_Detail");
        }

        /// <summary>
        /// Invalid request target: '{detail}'
        /// </summary>
        internal static string FormatBadRequest_InvalidRequestTarget_Detail(object detail)
            => string.Format(CultureInfo.CurrentCulture, GetString("BadRequest_InvalidRequestTarget_Detail", "detail"), detail);

        /// <summary>
        /// {detail} request contains no Content-Length or Transfer-Encoding header.
        /// </summary>
        internal static string BadRequest_LengthRequired
        {
            get => GetString("BadRequest_LengthRequired");
        }

        /// <summary>
        /// {detail} request contains no Content-Length or Transfer-Encoding header.
        /// </summary>
        internal static string FormatBadRequest_LengthRequired(object detail)
            => string.Format(CultureInfo.CurrentCulture, GetString("BadRequest_LengthRequired", "detail"), detail);

        /// <summary>
        /// {detail} request contains no Content-Length header.
        /// </summary>
        internal static string BadRequest_LengthRequiredHttp10
        {
            get => GetString("BadRequest_LengthRequiredHttp10");
        }

        /// <summary>
        /// {detail} request contains no Content-Length header.
        /// </summary>
        internal static string FormatBadRequest_LengthRequiredHttp10(object detail)
            => string.Format(CultureInfo.CurrentCulture, GetString("BadRequest_LengthRequiredHttp10", "detail"), detail);

        /// <summary>
        /// Malformed request: invalid headers.
        /// </summary>
        internal static string BadRequest_MalformedRequestInvalidHeaders
        {
            get => GetString("BadRequest_MalformedRequestInvalidHeaders");
        }

        /// <summary>
        /// Malformed request: invalid headers.
        /// </summary>
        internal static string FormatBadRequest_MalformedRequestInvalidHeaders()
            => GetString("BadRequest_MalformedRequestInvalidHeaders");

        /// <summary>
        /// Method not allowed.
        /// </summary>
        internal static string BadRequest_MethodNotAllowed
        {
            get => GetString("BadRequest_MethodNotAllowed");
        }

        /// <summary>
        /// Method not allowed.
        /// </summary>
        internal static string FormatBadRequest_MethodNotAllowed()
            => GetString("BadRequest_MethodNotAllowed");

        /// <summary>
        /// Request is missing Host header.
        /// </summary>
        internal static string BadRequest_MissingHostHeader
        {
            get => GetString("BadRequest_MissingHostHeader");
        }

        /// <summary>
        /// Request is missing Host header.
        /// </summary>
        internal static string FormatBadRequest_MissingHostHeader()
            => GetString("BadRequest_MissingHostHeader");

        /// <summary>
        /// Multiple Content-Length headers.
        /// </summary>
        internal static string BadRequest_MultipleContentLengths
        {
            get => GetString("BadRequest_MultipleContentLengths");
        }

        /// <summary>
        /// Multiple Content-Length headers.
        /// </summary>
        internal static string FormatBadRequest_MultipleContentLengths()
            => GetString("BadRequest_MultipleContentLengths");

        /// <summary>
        /// Multiple Host headers.
        /// </summary>
        internal static string BadRequest_MultipleHostHeaders
        {
            get => GetString("BadRequest_MultipleHostHeaders");
        }

        /// <summary>
        /// Multiple Host headers.
        /// </summary>
        internal static string FormatBadRequest_MultipleHostHeaders()
            => GetString("BadRequest_MultipleHostHeaders");

        /// <summary>
        /// Request line too long.
        /// </summary>
        internal static string BadRequest_RequestLineTooLong
        {
            get => GetString("BadRequest_RequestLineTooLong");
        }

        /// <summary>
        /// Request line too long.
        /// </summary>
        internal static string FormatBadRequest_RequestLineTooLong()
            => GetString("BadRequest_RequestLineTooLong");

        /// <summary>
        /// Reading the request headers timed out.
        /// </summary>
        internal static string BadRequest_RequestHeadersTimeout
        {
            get => GetString("BadRequest_RequestHeadersTimeout");
        }

        /// <summary>
        /// Reading the request headers timed out.
        /// </summary>
        internal static string FormatBadRequest_RequestHeadersTimeout()
            => GetString("BadRequest_RequestHeadersTimeout");

        /// <summary>
        /// Request contains too many headers.
        /// </summary>
        internal static string BadRequest_TooManyHeaders
        {
            get => GetString("BadRequest_TooManyHeaders");
        }

        /// <summary>
        /// Request contains too many headers.
        /// </summary>
        internal static string FormatBadRequest_TooManyHeaders()
            => GetString("BadRequest_TooManyHeaders");

        /// <summary>
        /// Unexpected end of request content.
        /// </summary>
        internal static string BadRequest_UnexpectedEndOfRequestContent
        {
            get => GetString("BadRequest_UnexpectedEndOfRequestContent");
        }

        /// <summary>
        /// Unexpected end of request content.
        /// </summary>
        internal static string FormatBadRequest_UnexpectedEndOfRequestContent()
            => GetString("BadRequest_UnexpectedEndOfRequestContent");

        /// <summary>
        /// Unrecognized HTTP version: '{detail}'
        /// </summary>
        internal static string BadRequest_UnrecognizedHTTPVersion
        {
            get => GetString("BadRequest_UnrecognizedHTTPVersion");
        }

        /// <summary>
        /// Unrecognized HTTP version: '{detail}'
        /// </summary>
        internal static string FormatBadRequest_UnrecognizedHTTPVersion(object detail)
            => string.Format(CultureInfo.CurrentCulture, GetString("BadRequest_UnrecognizedHTTPVersion", "detail"), detail);

        /// <summary>
        /// Requests with 'Connection: Upgrade' cannot have content in the request body.
        /// </summary>
        internal static string BadRequest_UpgradeRequestCannotHavePayload
        {
            get => GetString("BadRequest_UpgradeRequestCannotHavePayload");
        }

        /// <summary>
        /// Requests with 'Connection: Upgrade' cannot have content in the request body.
        /// </summary>
        internal static string FormatBadRequest_UpgradeRequestCannotHavePayload()
            => GetString("BadRequest_UpgradeRequestCannotHavePayload");

        /// <summary>
        /// Failed to bind to http://[::]:{port} (IPv6Any). Attempting to bind to http://0.0.0.0:{port} instead.
        /// </summary>
        internal static string FallbackToIPv4Any
        {
            get => GetString("FallbackToIPv4Any");
        }

        /// <summary>
        /// Failed to bind to http://[::]:{port} (IPv6Any). Attempting to bind to http://0.0.0.0:{port} instead.
        /// </summary>
        internal static string FormatFallbackToIPv4Any(object port)
            => string.Format(CultureInfo.CurrentCulture, GetString("FallbackToIPv4Any", "port"), port);

        /// <summary>
        /// Cannot write to response body after connection has been upgraded.
        /// </summary>
        internal static string ResponseStreamWasUpgraded
        {
            get => GetString("ResponseStreamWasUpgraded");
        }

        /// <summary>
        /// Cannot write to response body after connection has been upgraded.
        /// </summary>
        internal static string FormatResponseStreamWasUpgraded()
            => GetString("ResponseStreamWasUpgraded");

        /// <summary>
        /// Kestrel does not support big-endian architectures.
        /// </summary>
        internal static string BigEndianNotSupported
        {
            get => GetString("BigEndianNotSupported");
        }

        /// <summary>
        /// Kestrel does not support big-endian architectures.
        /// </summary>
        internal static string FormatBigEndianNotSupported()
            => GetString("BigEndianNotSupported");

        /// <summary>
        /// Maximum request buffer size ({requestBufferSize}) must be greater than or equal to maximum request header size ({requestHeaderSize}).
        /// </summary>
        internal static string MaxRequestBufferSmallerThanRequestHeaderBuffer
        {
            get => GetString("MaxRequestBufferSmallerThanRequestHeaderBuffer");
        }

        /// <summary>
        /// Maximum request buffer size ({requestBufferSize}) must be greater than or equal to maximum request header size ({requestHeaderSize}).
        /// </summary>
        internal static string FormatMaxRequestBufferSmallerThanRequestHeaderBuffer(object requestBufferSize, object requestHeaderSize)
            => string.Format(CultureInfo.CurrentCulture, GetString("MaxRequestBufferSmallerThanRequestHeaderBuffer", "requestBufferSize", "requestHeaderSize"), requestBufferSize, requestHeaderSize);

        /// <summary>
        /// Maximum request buffer size ({requestBufferSize}) must be greater than or equal to maximum request line size ({requestLineSize}).
        /// </summary>
        internal static string MaxRequestBufferSmallerThanRequestLineBuffer
        {
            get => GetString("MaxRequestBufferSmallerThanRequestLineBuffer");
        }

        /// <summary>
        /// Maximum request buffer size ({requestBufferSize}) must be greater than or equal to maximum request line size ({requestLineSize}).
        /// </summary>
        internal static string FormatMaxRequestBufferSmallerThanRequestLineBuffer(object requestBufferSize, object requestLineSize)
            => string.Format(CultureInfo.CurrentCulture, GetString("MaxRequestBufferSmallerThanRequestLineBuffer", "requestBufferSize", "requestLineSize"), requestBufferSize, requestLineSize);

        /// <summary>
        /// Server has already started.
        /// </summary>
        internal static string ServerAlreadyStarted
        {
            get => GetString("ServerAlreadyStarted");
        }

        /// <summary>
        /// Server has already started.
        /// </summary>
        internal static string FormatServerAlreadyStarted()
            => GetString("ServerAlreadyStarted");

        /// <summary>
        /// Unknown transport mode: '{mode}'.
        /// </summary>
        internal static string UnknownTransportMode
        {
            get => GetString("UnknownTransportMode");
        }

        /// <summary>
        /// Unknown transport mode: '{mode}'.
        /// </summary>
        internal static string FormatUnknownTransportMode(object mode)
            => string.Format(CultureInfo.CurrentCulture, GetString("UnknownTransportMode", "mode"), mode);

        /// <summary>
        /// Invalid non-ASCII or control character in header: {character}
        /// </summary>
        internal static string InvalidAsciiOrControlChar
        {
            get => GetString("InvalidAsciiOrControlChar");
        }

        /// <summary>
        /// Invalid non-ASCII or control character in header: {character}
        /// </summary>
        internal static string FormatInvalidAsciiOrControlChar(object character)
            => string.Format(CultureInfo.CurrentCulture, GetString("InvalidAsciiOrControlChar", "character"), character);

        /// <summary>
        /// Invalid Content-Length: "{value}". Value must be a positive integral number.
        /// </summary>
        internal static string InvalidContentLength_InvalidNumber
        {
            get => GetString("InvalidContentLength_InvalidNumber");
        }

        /// <summary>
        /// Invalid Content-Length: "{value}". Value must be a positive integral number.
        /// </summary>
        internal static string FormatInvalidContentLength_InvalidNumber(object value)
            => string.Format(CultureInfo.CurrentCulture, GetString("InvalidContentLength_InvalidNumber", "value"), value);

        /// <summary>
        /// Value must be null or a non-negative number.
        /// </summary>
        internal static string NonNegativeNumberOrNullRequired
        {
            get => GetString("NonNegativeNumberOrNullRequired");
        }

        /// <summary>
        /// Value must be null or a non-negative number.
        /// </summary>
        internal static string FormatNonNegativeNumberOrNullRequired()
            => GetString("NonNegativeNumberOrNullRequired");

        /// <summary>
        /// Value must be a non-negative number.
        /// </summary>
        internal static string NonNegativeNumberRequired
        {
            get => GetString("NonNegativeNumberRequired");
        }

        /// <summary>
        /// Value must be a non-negative number.
        /// </summary>
        internal static string FormatNonNegativeNumberRequired()
            => GetString("NonNegativeNumberRequired");

        /// <summary>
        /// Value must be a positive number.
        /// </summary>
        internal static string PositiveNumberRequired
        {
            get => GetString("PositiveNumberRequired");
        }

        /// <summary>
        /// Value must be a positive number.
        /// </summary>
        internal static string FormatPositiveNumberRequired()
            => GetString("PositiveNumberRequired");

        /// <summary>
        /// Value must be null or a positive number.
        /// </summary>
        internal static string PositiveNumberOrNullRequired
        {
            get => GetString("PositiveNumberOrNullRequired");
        }

        /// <summary>
        /// Value must be null or a positive number.
        /// </summary>
        internal static string FormatPositiveNumberOrNullRequired()
            => GetString("PositiveNumberOrNullRequired");

        /// <summary>
        /// Unix socket path must be absolute.
        /// </summary>
        internal static string UnixSocketPathMustBeAbsolute
        {
            get => GetString("UnixSocketPathMustBeAbsolute");
        }

        /// <summary>
        /// Unix socket path must be absolute.
        /// </summary>
        internal static string FormatUnixSocketPathMustBeAbsolute()
            => GetString("UnixSocketPathMustBeAbsolute");

        /// <summary>
        /// Failed to bind to address {address}.
        /// </summary>
        internal static string AddressBindingFailed
        {
            get => GetString("AddressBindingFailed");
        }

        /// <summary>
        /// Failed to bind to address {address}.
        /// </summary>
        internal static string FormatAddressBindingFailed(object address)
            => string.Format(CultureInfo.CurrentCulture, GetString("AddressBindingFailed", "address"), address);

        /// <summary>
        /// No listening endpoints were configured. Binding to {address} by default.
        /// </summary>
        internal static string BindingToDefaultAddress
        {
            get => GetString("BindingToDefaultAddress");
        }

        /// <summary>
        /// No listening endpoints were configured. Binding to {address} by default.
        /// </summary>
        internal static string FormatBindingToDefaultAddress(object address)
            => string.Format(CultureInfo.CurrentCulture, GetString("BindingToDefaultAddress", "address"), address);

        /// <summary>
        /// HTTPS endpoints can only be configured using {methodName}.
        /// </summary>
        internal static string ConfigureHttpsFromMethodCall
        {
            get => GetString("ConfigureHttpsFromMethodCall");
        }

        /// <summary>
        /// HTTPS endpoints can only be configured using {methodName}.
        /// </summary>
        internal static string FormatConfigureHttpsFromMethodCall(object methodName)
            => string.Format(CultureInfo.CurrentCulture, GetString("ConfigureHttpsFromMethodCall", "methodName"), methodName);

        /// <summary>
        /// A path base can only be configured using {methodName}.
        /// </summary>
        internal static string ConfigurePathBaseFromMethodCall
        {
            get => GetString("ConfigurePathBaseFromMethodCall");
        }

        /// <summary>
        /// A path base can only be configured using {methodName}.
        /// </summary>
        internal static string FormatConfigurePathBaseFromMethodCall(object methodName)
            => string.Format(CultureInfo.CurrentCulture, GetString("ConfigurePathBaseFromMethodCall", "methodName"), methodName);

        /// <summary>
        /// Dynamic port binding is not supported when binding to localhost. You must either bind to 127.0.0.1:0 or [::1]:0, or both.
        /// </summary>
        internal static string DynamicPortOnLocalhostNotSupported
        {
            get => GetString("DynamicPortOnLocalhostNotSupported");
        }

        /// <summary>
        /// Dynamic port binding is not supported when binding to localhost. You must either bind to 127.0.0.1:0 or [::1]:0, or both.
        /// </summary>
        internal static string FormatDynamicPortOnLocalhostNotSupported()
            => GetString("DynamicPortOnLocalhostNotSupported");

        /// <summary>
        /// Failed to bind to address {endpoint}: address already in use.
        /// </summary>
        internal static string EndpointAlreadyInUse
        {
            get => GetString("EndpointAlreadyInUse");
        }

        /// <summary>
        /// Failed to bind to address {endpoint}: address already in use.
        /// </summary>
        internal static string FormatEndpointAlreadyInUse(object endpoint)
            => string.Format(CultureInfo.CurrentCulture, GetString("EndpointAlreadyInUse", "endpoint"), endpoint);

        /// <summary>
        /// Invalid URL: '{url}'.
        /// </summary>
        internal static string InvalidUrl
        {
            get => GetString("InvalidUrl");
        }

        /// <summary>
        /// Invalid URL: '{url}'.
        /// </summary>
        internal static string FormatInvalidUrl(object url)
            => string.Format(CultureInfo.CurrentCulture, GetString("InvalidUrl", "url"), url);

        /// <summary>
        /// Unable to bind to {address} on the {interfaceName} interface: '{error}'.
        /// </summary>
        internal static string NetworkInterfaceBindingFailed
        {
            get => GetString("NetworkInterfaceBindingFailed");
        }

        /// <summary>
        /// Unable to bind to {address} on the {interfaceName} interface: '{error}'.
        /// </summary>
        internal static string FormatNetworkInterfaceBindingFailed(object address, object interfaceName, object error)
            => string.Format(CultureInfo.CurrentCulture, GetString("NetworkInterfaceBindingFailed", "address", "interfaceName", "error"), address, interfaceName, error);

        /// <summary>
        /// Overriding address(es) '{addresses}'. Binding to endpoints defined in {methodName} instead.
        /// </summary>
        internal static string OverridingWithKestrelOptions
        {
            get => GetString("OverridingWithKestrelOptions");
        }

        /// <summary>
        /// Overriding address(es) '{addresses}'. Binding to endpoints defined in {methodName} instead.
        /// </summary>
        internal static string FormatOverridingWithKestrelOptions(object addresses, object methodName)
            => string.Format(CultureInfo.CurrentCulture, GetString("OverridingWithKestrelOptions", "addresses", "methodName"), addresses, methodName);

        /// <summary>
        /// Overriding endpoints defined in UseKestrel() because {settingName} is set to true. Binding to address(es) '{addresses}' instead.
        /// </summary>
        internal static string OverridingWithPreferHostingUrls
        {
            get => GetString("OverridingWithPreferHostingUrls");
        }

        /// <summary>
        /// Overriding endpoints defined in UseKestrel() because {settingName} is set to true. Binding to address(es) '{addresses}' instead.
        /// </summary>
        internal static string FormatOverridingWithPreferHostingUrls(object settingName, object addresses)
            => string.Format(CultureInfo.CurrentCulture, GetString("OverridingWithPreferHostingUrls", "settingName", "addresses"), settingName, addresses);

        /// <summary>
        /// Unrecognized scheme in server address '{address}'. Only 'http://' is supported.
        /// </summary>
        internal static string UnsupportedAddressScheme
        {
            get => GetString("UnsupportedAddressScheme");
        }

        /// <summary>
        /// Unrecognized scheme in server address '{address}'. Only 'http://' is supported.
        /// </summary>
        internal static string FormatUnsupportedAddressScheme(object address)
            => string.Format(CultureInfo.CurrentCulture, GetString("UnsupportedAddressScheme", "address"), address);

        /// <summary>
        /// Headers are read-only, response has already started.
        /// </summary>
        internal static string HeadersAreReadOnly
        {
            get => GetString("HeadersAreReadOnly");
        }

        /// <summary>
        /// Headers are read-only, response has already started.
        /// </summary>
        internal static string FormatHeadersAreReadOnly()
            => GetString("HeadersAreReadOnly");

        /// <summary>
        /// An item with the same key has already been added.
        /// </summary>
        internal static string KeyAlreadyExists
        {
            get => GetString("KeyAlreadyExists");
        }

        /// <summary>
        /// An item with the same key has already been added.
        /// </summary>
        internal static string FormatKeyAlreadyExists()
            => GetString("KeyAlreadyExists");

        /// <summary>
        /// Setting the header {name} is not allowed on responses with status code {statusCode}.
        /// </summary>
        internal static string HeaderNotAllowedOnResponse
        {
            get => GetString("HeaderNotAllowedOnResponse");
        }

        /// <summary>
        /// Setting the header {name} is not allowed on responses with status code {statusCode}.
        /// </summary>
        internal static string FormatHeaderNotAllowedOnResponse(object name, object statusCode)
            => string.Format(CultureInfo.CurrentCulture, GetString("HeaderNotAllowedOnResponse", "name", "statusCode"), name, statusCode);

        /// <summary>
        /// {name} cannot be set because the response has already started.
        /// </summary>
        internal static string ParameterReadOnlyAfterResponseStarted
        {
            get => GetString("ParameterReadOnlyAfterResponseStarted");
        }

        /// <summary>
        /// {name} cannot be set because the response has already started.
        /// </summary>
        internal static string FormatParameterReadOnlyAfterResponseStarted(object name)
            => string.Format(CultureInfo.CurrentCulture, GetString("ParameterReadOnlyAfterResponseStarted", "name"), name);

        /// <summary>
        /// Request processing didn't complete within the shutdown timeout.
        /// </summary>
        internal static string RequestProcessingAborted
        {
            get => GetString("RequestProcessingAborted");
        }

        /// <summary>
        /// Request processing didn't complete within the shutdown timeout.
        /// </summary>
        internal static string FormatRequestProcessingAborted()
            => GetString("RequestProcessingAborted");

        /// <summary>
        /// Response Content-Length mismatch: too few bytes written ({written} of {expected}).
        /// </summary>
        internal static string TooFewBytesWritten
        {
            get => GetString("TooFewBytesWritten");
        }

        /// <summary>
        /// Response Content-Length mismatch: too few bytes written ({written} of {expected}).
        /// </summary>
        internal static string FormatTooFewBytesWritten(object written, object expected)
            => string.Format(CultureInfo.CurrentCulture, GetString("TooFewBytesWritten", "written", "expected"), written, expected);

        /// <summary>
        /// Response Content-Length mismatch: too many bytes written ({written} of {expected}).
        /// </summary>
        internal static string TooManyBytesWritten
        {
            get => GetString("TooManyBytesWritten");
        }

        /// <summary>
        /// Response Content-Length mismatch: too many bytes written ({written} of {expected}).
        /// </summary>
        internal static string FormatTooManyBytesWritten(object written, object expected)
            => string.Format(CultureInfo.CurrentCulture, GetString("TooManyBytesWritten", "written", "expected"), written, expected);

        /// <summary>
        /// The response has been aborted due to an unhandled application exception.
        /// </summary>
        internal static string UnhandledApplicationException
        {
            get => GetString("UnhandledApplicationException");
        }

        /// <summary>
        /// The response has been aborted due to an unhandled application exception.
        /// </summary>
        internal static string FormatUnhandledApplicationException()
            => GetString("UnhandledApplicationException");

        /// <summary>
        /// Writing to the response body is invalid for responses with status code {statusCode}.
        /// </summary>
        internal static string WritingToResponseBodyNotSupported
        {
            get => GetString("WritingToResponseBodyNotSupported");
        }

        /// <summary>
        /// Writing to the response body is invalid for responses with status code {statusCode}.
        /// </summary>
        internal static string FormatWritingToResponseBodyNotSupported(object statusCode)
            => string.Format(CultureInfo.CurrentCulture, GetString("WritingToResponseBodyNotSupported", "statusCode"), statusCode);

        /// <summary>
        /// Connection shutdown abnormally.
        /// </summary>
        internal static string ConnectionShutdownError
        {
            get => GetString("ConnectionShutdownError");
        }

        /// <summary>
        /// Connection shutdown abnormally.
        /// </summary>
        internal static string FormatConnectionShutdownError()
            => GetString("ConnectionShutdownError");

        /// <summary>
        /// Connection processing ended abnormally.
        /// </summary>
        internal static string RequestProcessingEndError
        {
            get => GetString("RequestProcessingEndError");
        }

        /// <summary>
        /// Connection processing ended abnormally.
        /// </summary>
        internal static string FormatRequestProcessingEndError()
            => GetString("RequestProcessingEndError");

        /// <summary>
        /// Cannot upgrade a non-upgradable request. Check IHttpUpgradeFeature.IsUpgradableRequest to determine if a request can be upgraded.
        /// </summary>
        internal static string CannotUpgradeNonUpgradableRequest
        {
            get => GetString("CannotUpgradeNonUpgradableRequest");
        }

        /// <summary>
        /// Cannot upgrade a non-upgradable request. Check IHttpUpgradeFeature.IsUpgradableRequest to determine if a request can be upgraded.
        /// </summary>
        internal static string FormatCannotUpgradeNonUpgradableRequest()
            => GetString("CannotUpgradeNonUpgradableRequest");

        /// <summary>
        /// Request cannot be upgraded because the server has already opened the maximum number of upgraded connections.
        /// </summary>
        internal static string UpgradedConnectionLimitReached
        {
            get => GetString("UpgradedConnectionLimitReached");
        }

        /// <summary>
        /// Request cannot be upgraded because the server has already opened the maximum number of upgraded connections.
        /// </summary>
        internal static string FormatUpgradedConnectionLimitReached()
            => GetString("UpgradedConnectionLimitReached");

        /// <summary>
        /// IHttpUpgradeFeature.UpgradeAsync was already called and can only be called once per connection.
        /// </summary>
        internal static string UpgradeCannotBeCalledMultipleTimes
        {
            get => GetString("UpgradeCannotBeCalledMultipleTimes");
        }

        /// <summary>
        /// IHttpUpgradeFeature.UpgradeAsync was already called and can only be called once per connection.
        /// </summary>
        internal static string FormatUpgradeCannotBeCalledMultipleTimes()
            => GetString("UpgradeCannotBeCalledMultipleTimes");

        /// <summary>
        /// Request body too large.
        /// </summary>
        internal static string BadRequest_RequestBodyTooLarge
        {
            get => GetString("BadRequest_RequestBodyTooLarge");
        }

        /// <summary>
        /// Request body too large.
        /// </summary>
        internal static string FormatBadRequest_RequestBodyTooLarge()
            => GetString("BadRequest_RequestBodyTooLarge");

        /// <summary>
        /// The maximum request body size cannot be modified after the app has already started reading from the request body.
        /// </summary>
        internal static string MaxRequestBodySizeCannotBeModifiedAfterRead
        {
            get => GetString("MaxRequestBodySizeCannotBeModifiedAfterRead");
        }

        /// <summary>
        /// The maximum request body size cannot be modified after the app has already started reading from the request body.
        /// </summary>
        internal static string FormatMaxRequestBodySizeCannotBeModifiedAfterRead()
            => GetString("MaxRequestBodySizeCannotBeModifiedAfterRead");

        /// <summary>
        /// The maximum request body size cannot be modified after the request has been upgraded.
        /// </summary>
        internal static string MaxRequestBodySizeCannotBeModifiedForUpgradedRequests
        {
            get => GetString("MaxRequestBodySizeCannotBeModifiedForUpgradedRequests");
        }

        /// <summary>
        /// The maximum request body size cannot be modified after the request has been upgraded.
        /// </summary>
        internal static string FormatMaxRequestBodySizeCannotBeModifiedForUpgradedRequests()
            => GetString("MaxRequestBodySizeCannotBeModifiedForUpgradedRequests");

        /// <summary>
        /// Value must be a positive TimeSpan.
        /// </summary>
        internal static string PositiveTimeSpanRequired
        {
            get => GetString("PositiveTimeSpanRequired");
        }

        /// <summary>
        /// Value must be a positive TimeSpan.
        /// </summary>
        internal static string FormatPositiveTimeSpanRequired()
            => GetString("PositiveTimeSpanRequired");

        /// <summary>
        /// Value must be a non-negative TimeSpan.
        /// </summary>
        internal static string NonNegativeTimeSpanRequired
        {
            get => GetString("NonNegativeTimeSpanRequired");
        }

        /// <summary>
        /// Value must be a non-negative TimeSpan.
        /// </summary>
        internal static string FormatNonNegativeTimeSpanRequired()
            => GetString("NonNegativeTimeSpanRequired");

        /// <summary>
        /// The request body rate enforcement grace period must be greater than {heartbeatInterval} second.
        /// </summary>
        internal static string MinimumGracePeriodRequired
        {
            get => GetString("MinimumGracePeriodRequired");
        }

        /// <summary>
        /// The request body rate enforcement grace period must be greater than {heartbeatInterval} second.
        /// </summary>
        internal static string FormatMinimumGracePeriodRequired(object heartbeatInterval)
            => string.Format(CultureInfo.CurrentCulture, GetString("MinimumGracePeriodRequired", "heartbeatInterval"), heartbeatInterval);

        /// <summary>
        /// Synchronous operations are disallowed. Call ReadAsync or set AllowSynchronousIO to true instead.
        /// </summary>
        internal static string SynchronousReadsDisallowed
        {
            get => GetString("SynchronousReadsDisallowed");
        }

        /// <summary>
        /// Synchronous operations are disallowed. Call ReadAsync or set AllowSynchronousIO to true instead.
        /// </summary>
        internal static string FormatSynchronousReadsDisallowed()
            => GetString("SynchronousReadsDisallowed");

        /// <summary>
        /// Synchronous operations are disallowed. Call WriteAsync or set AllowSynchronousIO to true instead.
        /// </summary>
        internal static string SynchronousWritesDisallowed
        {
            get => GetString("SynchronousWritesDisallowed");
        }

        /// <summary>
        /// Synchronous operations are disallowed. Call WriteAsync or set AllowSynchronousIO to true instead.
        /// </summary>
        internal static string FormatSynchronousWritesDisallowed()
            => GetString("SynchronousWritesDisallowed");

        /// <summary>
        /// Value must be a positive number. To disable a minimum data rate, use null where a MinDataRate instance is expected.
        /// </summary>
        internal static string PositiveNumberOrNullMinDataRateRequired
        {
            get => GetString("PositiveNumberOrNullMinDataRateRequired");
        }

        /// <summary>
        /// Value must be a positive number. To disable a minimum data rate, use null where a MinDataRate instance is expected.
        /// </summary>
        internal static string FormatPositiveNumberOrNullMinDataRateRequired()
            => GetString("PositiveNumberOrNullMinDataRateRequired");

        /// <summary>
        /// Concurrent timeouts are not supported.
        /// </summary>
        internal static string ConcurrentTimeoutsNotSupported
        {
            get => GetString("ConcurrentTimeoutsNotSupported");
        }

        /// <summary>
        /// Concurrent timeouts are not supported.
        /// </summary>
        internal static string FormatConcurrentTimeoutsNotSupported()
            => GetString("ConcurrentTimeoutsNotSupported");

        /// <summary>
        /// Timespan must be positive and finite.
        /// </summary>
        internal static string PositiveFiniteTimeSpanRequired
        {
            get => GetString("PositiveFiniteTimeSpanRequired");
        }

        /// <summary>
        /// Timespan must be positive and finite.
        /// </summary>
        internal static string FormatPositiveFiniteTimeSpanRequired()
            => GetString("PositiveFiniteTimeSpanRequired");

        /// <summary>
        /// An endpoint must be configured to serve at least one protocol.
        /// </summary>
        internal static string EndPointRequiresAtLeastOneProtocol
        {
            get => GetString("EndPointRequiresAtLeastOneProtocol");
        }

        /// <summary>
        /// An endpoint must be configured to serve at least one protocol.
        /// </summary>
        internal static string FormatEndPointRequiresAtLeastOneProtocol()
            => GetString("EndPointRequiresAtLeastOneProtocol");

        /// <summary>
        /// HTTP/2 over TLS was not negotiated on an HTTP/2-only endpoint.
        /// </summary>
        internal static string EndPointHttp2NotNegotiated
        {
            get => GetString("EndPointHttp2NotNegotiated");
        }

        /// <summary>
        /// HTTP/2 over TLS was not negotiated on an HTTP/2-only endpoint.
        /// </summary>
        internal static string FormatEndPointHttp2NotNegotiated()
            => GetString("EndPointHttp2NotNegotiated");

        /// <summary>
        /// A dynamic table size of {size} octets is greater than the configured maximum size of {maxSize} octets.
        /// </summary>
        internal static string HPackErrorDynamicTableSizeUpdateTooLarge
        {
            get => GetString("HPackErrorDynamicTableSizeUpdateTooLarge");
        }

        /// <summary>
        /// A dynamic table size of {size} octets is greater than the configured maximum size of {maxSize} octets.
        /// </summary>
        internal static string FormatHPackErrorDynamicTableSizeUpdateTooLarge(object size, object maxSize)
            => string.Format(CultureInfo.CurrentCulture, GetString("HPackErrorDynamicTableSizeUpdateTooLarge", "size", "maxSize"), size, maxSize);

        /// <summary>
        /// Index {index} is outside the bounds of the header field table.
        /// </summary>
        internal static string HPackErrorIndexOutOfRange
        {
            get => GetString("HPackErrorIndexOutOfRange");
        }

        /// <summary>
        /// Index {index} is outside the bounds of the header field table.
        /// </summary>
        internal static string FormatHPackErrorIndexOutOfRange(object index)
            => string.Format(CultureInfo.CurrentCulture, GetString("HPackErrorIndexOutOfRange", "index"), index);

        /// <summary>
        /// Input data could not be fully decoded.
        /// </summary>
        internal static string HPackHuffmanErrorIncomplete
        {
            get => GetString("HPackHuffmanErrorIncomplete");
        }

        /// <summary>
        /// Input data could not be fully decoded.
        /// </summary>
        internal static string FormatHPackHuffmanErrorIncomplete()
            => GetString("HPackHuffmanErrorIncomplete");

        /// <summary>
        /// Input data contains the EOS symbol.
        /// </summary>
        internal static string HPackHuffmanErrorEOS
        {
            get => GetString("HPackHuffmanErrorEOS");
        }

        /// <summary>
        /// Input data contains the EOS symbol.
        /// </summary>
        internal static string FormatHPackHuffmanErrorEOS()
            => GetString("HPackHuffmanErrorEOS");

        /// <summary>
        /// The destination buffer is not large enough to store the decoded data.
        /// </summary>
        internal static string HPackHuffmanErrorDestinationTooSmall
        {
            get => GetString("HPackHuffmanErrorDestinationTooSmall");
        }

        /// <summary>
        /// The destination buffer is not large enough to store the decoded data.
        /// </summary>
        internal static string FormatHPackHuffmanErrorDestinationTooSmall()
            => GetString("HPackHuffmanErrorDestinationTooSmall");

        /// <summary>
        /// Huffman decoding error.
        /// </summary>
        internal static string HPackHuffmanError
        {
            get => GetString("HPackHuffmanError");
        }

        /// <summary>
        /// Huffman decoding error.
        /// </summary>
        internal static string FormatHPackHuffmanError()
            => GetString("HPackHuffmanError");

        /// <summary>
        /// Decoded string length of {length} octets is greater than the configured maximum length of {maxStringLength} octets.
        /// </summary>
        internal static string HPackStringLengthTooLarge
        {
            get => GetString("HPackStringLengthTooLarge");
        }

        /// <summary>
        /// Decoded string length of {length} octets is greater than the configured maximum length of {maxStringLength} octets.
        /// </summary>
        internal static string FormatHPackStringLengthTooLarge(object length, object maxStringLength)
            => string.Format(CultureInfo.CurrentCulture, GetString("HPackStringLengthTooLarge", "length", "maxStringLength"), length, maxStringLength);

        /// <summary>
        /// The header block was incomplete and could not be fully decoded.
        /// </summary>
        internal static string HPackErrorIncompleteHeaderBlock
        {
            get => GetString("HPackErrorIncompleteHeaderBlock");
        }

        /// <summary>
        /// The header block was incomplete and could not be fully decoded.
        /// </summary>
        internal static string FormatHPackErrorIncompleteHeaderBlock()
            => GetString("HPackErrorIncompleteHeaderBlock");

        /// <summary>
        /// The client sent a {frameType} frame with even stream ID {streamId}.
        /// </summary>
        internal static string Http2ErrorStreamIdEven
        {
            get => GetString("Http2ErrorStreamIdEven");
        }

        /// <summary>
        /// The client sent a {frameType} frame with even stream ID {streamId}.
        /// </summary>
        internal static string FormatHttp2ErrorStreamIdEven(object frameType, object streamId)
            => string.Format(CultureInfo.CurrentCulture, GetString("Http2ErrorStreamIdEven", "frameType", "streamId"), frameType, streamId);

        /// <summary>
        /// The client sent a A PUSH_PROMISE frame.
        /// </summary>
        internal static string Http2ErrorPushPromiseReceived
        {
            get => GetString("Http2ErrorPushPromiseReceived");
        }

        /// <summary>
        /// The client sent a A PUSH_PROMISE frame.
        /// </summary>
        internal static string FormatHttp2ErrorPushPromiseReceived()
            => GetString("Http2ErrorPushPromiseReceived");

        /// <summary>
        /// The client sent a {frameType} frame to stream ID {streamId} before signaling of the header block for stream ID {headersStreamId}.
        /// </summary>
        internal static string Http2ErrorHeadersInterleaved
        {
            get => GetString("Http2ErrorHeadersInterleaved");
        }

        /// <summary>
        /// The client sent a {frameType} frame to stream ID {streamId} before signaling of the header block for stream ID {headersStreamId}.
        /// </summary>
        internal static string FormatHttp2ErrorHeadersInterleaved(object frameType, object streamId, object headersStreamId)
            => string.Format(CultureInfo.CurrentCulture, GetString("Http2ErrorHeadersInterleaved", "frameType", "streamId", "headersStreamId"), frameType, streamId, headersStreamId);

        /// <summary>
        /// The client sent a {frameType} frame with stream ID 0.
        /// </summary>
        internal static string Http2ErrorStreamIdZero
        {
            get => GetString("Http2ErrorStreamIdZero");
        }

        /// <summary>
        /// The client sent a {frameType} frame with stream ID 0.
        /// </summary>
        internal static string FormatHttp2ErrorStreamIdZero(object frameType)
            => string.Format(CultureInfo.CurrentCulture, GetString("Http2ErrorStreamIdZero", "frameType"), frameType);

        /// <summary>
        /// The client sent a {frameType} frame with stream ID different than 0.
        /// </summary>
        internal static string Http2ErrorStreamIdNotZero
        {
            get => GetString("Http2ErrorStreamIdNotZero");
        }

        /// <summary>
        /// The client sent a {frameType} frame with stream ID different than 0.
        /// </summary>
        internal static string FormatHttp2ErrorStreamIdNotZero(object frameType)
            => string.Format(CultureInfo.CurrentCulture, GetString("Http2ErrorStreamIdNotZero", "frameType"), frameType);

        /// <summary>
        /// The client sent a {frameType} frame with padding longer than or with the same length as the sent data.
        /// </summary>
        internal static string Http2ErrorPaddingTooLong
        {
            get => GetString("Http2ErrorPaddingTooLong");
        }

        /// <summary>
        /// The client sent a {frameType} frame with padding longer than or with the same length as the sent data.
        /// </summary>
        internal static string FormatHttp2ErrorPaddingTooLong(object frameType)
            => string.Format(CultureInfo.CurrentCulture, GetString("Http2ErrorPaddingTooLong", "frameType"), frameType);

        /// <summary>
        /// The client sent a {frameType} frame to closed stream ID {streamId}.
        /// </summary>
        internal static string Http2ErrorStreamClosed
        {
            get => GetString("Http2ErrorStreamClosed");
        }

        /// <summary>
        /// The client sent a {frameType} frame to closed stream ID {streamId}.
        /// </summary>
        internal static string FormatHttp2ErrorStreamClosed(object frameType, object streamId)
            => string.Format(CultureInfo.CurrentCulture, GetString("Http2ErrorStreamClosed", "frameType", "streamId"), frameType, streamId);

        /// <summary>
        /// The client sent a {frameType} frame to stream ID {streamId} which is in the "half-closed (remote) state".
        /// </summary>
        internal static string Http2ErrorStreamHalfClosedRemote
        {
            get => GetString("Http2ErrorStreamHalfClosedRemote");
        }

        /// <summary>
        /// The client sent a {frameType} frame to stream ID {streamId} which is in the "half-closed (remote) state".
        /// </summary>
        internal static string FormatHttp2ErrorStreamHalfClosedRemote(object frameType, object streamId)
            => string.Format(CultureInfo.CurrentCulture, GetString("Http2ErrorStreamHalfClosedRemote", "frameType", "streamId"), frameType, streamId);

        /// <summary>
        /// The client sent a {frameType} frame with dependency information that would cause stream ID {streamId} to depend on itself.
        /// </summary>
        internal static string Http2ErrorStreamSelfDependency
        {
            get => GetString("Http2ErrorStreamSelfDependency");
        }

        /// <summary>
        /// The client sent a {frameType} frame with dependency information that would cause stream ID {streamId} to depend on itself.
        /// </summary>
        internal static string FormatHttp2ErrorStreamSelfDependency(object frameType, object streamId)
            => string.Format(CultureInfo.CurrentCulture, GetString("Http2ErrorStreamSelfDependency", "frameType", "streamId"), frameType, streamId);

        /// <summary>
        /// The client sent a {frameType} frame with length different than {expectedLength}.
        /// </summary>
        internal static string Http2ErrorUnexpectedFrameLength
        {
            get => GetString("Http2ErrorUnexpectedFrameLength");
        }

        /// <summary>
        /// The client sent a {frameType} frame with length different than {expectedLength}.
        /// </summary>
        internal static string FormatHttp2ErrorUnexpectedFrameLength(object frameType, object expectedLength)
            => string.Format(CultureInfo.CurrentCulture, GetString("Http2ErrorUnexpectedFrameLength", "frameType", "expectedLength"), frameType, expectedLength);

        /// <summary>
        /// The client sent a SETTINGS frame with a length that is not a multiple of 6.
        /// </summary>
        internal static string Http2ErrorSettingsLengthNotMultipleOfSix
        {
            get => GetString("Http2ErrorSettingsLengthNotMultipleOfSix");
        }

        /// <summary>
        /// The client sent a SETTINGS frame with a length that is not a multiple of 6.
        /// </summary>
        internal static string FormatHttp2ErrorSettingsLengthNotMultipleOfSix()
            => GetString("Http2ErrorSettingsLengthNotMultipleOfSix");

        /// <summary>
        /// The client sent a SETTINGS frame with ACK set and length different than 0.
        /// </summary>
        internal static string Http2ErrorSettingsAckLengthNotZero
        {
            get => GetString("Http2ErrorSettingsAckLengthNotZero");
        }

        /// <summary>
        /// The client sent a SETTINGS frame with ACK set and length different than 0.
        /// </summary>
        internal static string FormatHttp2ErrorSettingsAckLengthNotZero()
            => GetString("Http2ErrorSettingsAckLengthNotZero");

        /// <summary>
        /// The client sent a SETTINGS frame with a value for parameter {parameter} that is out of range.
        /// </summary>
        internal static string Http2ErrorSettingsParameterOutOfRange
        {
            get => GetString("Http2ErrorSettingsParameterOutOfRange");
        }

        /// <summary>
        /// The client sent a SETTINGS frame with a value for parameter {parameter} that is out of range.
        /// </summary>
        internal static string FormatHttp2ErrorSettingsParameterOutOfRange(object parameter)
            => string.Format(CultureInfo.CurrentCulture, GetString("Http2ErrorSettingsParameterOutOfRange", "parameter"), parameter);

        /// <summary>
        /// The client sent a WINDOW_UPDATE frame with a window size increment of 0.
        /// </summary>
        internal static string Http2ErrorWindowUpdateIncrementZero
        {
            get => GetString("Http2ErrorWindowUpdateIncrementZero");
        }

        /// <summary>
        /// The client sent a WINDOW_UPDATE frame with a window size increment of 0.
        /// </summary>
        internal static string FormatHttp2ErrorWindowUpdateIncrementZero()
            => GetString("Http2ErrorWindowUpdateIncrementZero");

        /// <summary>
        /// The client sent a CONTINUATION frame not preceded by a HEADERS frame.
        /// </summary>
        internal static string Http2ErrorContinuationWithNoHeaders
        {
            get => GetString("Http2ErrorContinuationWithNoHeaders");
        }

        /// <summary>
        /// The client sent a CONTINUATION frame not preceded by a HEADERS frame.
        /// </summary>
        internal static string FormatHttp2ErrorContinuationWithNoHeaders()
            => GetString("Http2ErrorContinuationWithNoHeaders");

        /// <summary>
        /// The client sent a {frameType} frame to idle stream ID {streamId}.
        /// </summary>
        internal static string Http2ErrorStreamIdle
        {
            get => GetString("Http2ErrorStreamIdle");
        }

        /// <summary>
        /// The client sent a {frameType} frame to idle stream ID {streamId}.
        /// </summary>
        internal static string FormatHttp2ErrorStreamIdle(object frameType, object streamId)
            => string.Format(CultureInfo.CurrentCulture, GetString("Http2ErrorStreamIdle", "frameType", "streamId"), frameType, streamId);

        /// <summary>
        /// The client sent trailers containing one or more pseudo-header fields.
        /// </summary>
        internal static string Http2ErrorTrailersContainPseudoHeaderField
        {
            get => GetString("Http2ErrorTrailersContainPseudoHeaderField");
        }

        /// <summary>
        /// The client sent trailers containing one or more pseudo-header fields.
        /// </summary>
        internal static string FormatHttp2ErrorTrailersContainPseudoHeaderField()
            => GetString("Http2ErrorTrailersContainPseudoHeaderField");

        /// <summary>
        /// The client sent a header with uppercase characters in its name.
        /// </summary>
        internal static string Http2ErrorHeaderNameUppercase
        {
            get => GetString("Http2ErrorHeaderNameUppercase");
        }

        /// <summary>
        /// The client sent a header with uppercase characters in its name.
        /// </summary>
        internal static string FormatHttp2ErrorHeaderNameUppercase()
            => GetString("Http2ErrorHeaderNameUppercase");

        /// <summary>
        /// The client sent a trailer with uppercase characters in its name.
        /// </summary>
        internal static string Http2ErrorTrailerNameUppercase
        {
            get => GetString("Http2ErrorTrailerNameUppercase");
        }

        /// <summary>
        /// The client sent a trailer with uppercase characters in its name.
        /// </summary>
        internal static string FormatHttp2ErrorTrailerNameUppercase()
            => GetString("Http2ErrorTrailerNameUppercase");

        /// <summary>
        /// The client sent a HEADERS frame containing trailers without setting the END_STREAM flag.
        /// </summary>
        internal static string Http2ErrorHeadersWithTrailersNoEndStream
        {
            get => GetString("Http2ErrorHeadersWithTrailersNoEndStream");
        }

        /// <summary>
        /// The client sent a HEADERS frame containing trailers without setting the END_STREAM flag.
        /// </summary>
        internal static string FormatHttp2ErrorHeadersWithTrailersNoEndStream()
            => GetString("Http2ErrorHeadersWithTrailersNoEndStream");

        /// <summary>
        /// Request headers missing one or more mandatory pseudo-header fields.
        /// </summary>
        internal static string Http2ErrorMissingMandatoryPseudoHeaderFields
        {
            get => GetString("Http2ErrorMissingMandatoryPseudoHeaderFields");
        }

        /// <summary>
        /// Request headers missing one or more mandatory pseudo-header fields.
        /// </summary>
        internal static string FormatHttp2ErrorMissingMandatoryPseudoHeaderFields()
            => GetString("Http2ErrorMissingMandatoryPseudoHeaderFields");

        /// <summary>
        /// Pseudo-header field found in request headers after regular header fields.
        /// </summary>
        internal static string Http2ErrorPseudoHeaderFieldAfterRegularHeaders
        {
            get => GetString("Http2ErrorPseudoHeaderFieldAfterRegularHeaders");
        }

        /// <summary>
        /// Pseudo-header field found in request headers after regular header fields.
        /// </summary>
        internal static string FormatHttp2ErrorPseudoHeaderFieldAfterRegularHeaders()
            => GetString("Http2ErrorPseudoHeaderFieldAfterRegularHeaders");

        /// <summary>
        /// Request headers contain unknown pseudo-header field.
        /// </summary>
        internal static string Http2ErrorUnknownPseudoHeaderField
        {
            get => GetString("Http2ErrorUnknownPseudoHeaderField");
        }

        /// <summary>
        /// Request headers contain unknown pseudo-header field.
        /// </summary>
        internal static string FormatHttp2ErrorUnknownPseudoHeaderField()
            => GetString("Http2ErrorUnknownPseudoHeaderField");

        /// <summary>
        /// Request headers contain response-specific pseudo-header field.
        /// </summary>
        internal static string Http2ErrorResponsePseudoHeaderField
        {
            get => GetString("Http2ErrorResponsePseudoHeaderField");
        }

        /// <summary>
        /// Request headers contain response-specific pseudo-header field.
        /// </summary>
        internal static string FormatHttp2ErrorResponsePseudoHeaderField()
            => GetString("Http2ErrorResponsePseudoHeaderField");

        /// <summary>
        /// Request headers contain duplicate pseudo-header field.
        /// </summary>
        internal static string Http2ErrorDuplicatePseudoHeaderField
        {
            get => GetString("Http2ErrorDuplicatePseudoHeaderField");
        }

        /// <summary>
        /// Request headers contain duplicate pseudo-header field.
        /// </summary>
        internal static string FormatHttp2ErrorDuplicatePseudoHeaderField()
            => GetString("Http2ErrorDuplicatePseudoHeaderField");

        /// <summary>
        /// Request headers contain connection-specific header field.
        /// </summary>
        internal static string Http2ErrorConnectionSpecificHeaderField
        {
            get => GetString("Http2ErrorConnectionSpecificHeaderField");
        }

        /// <summary>
        /// Request headers contain connection-specific header field.
        /// </summary>
        internal static string FormatHttp2ErrorConnectionSpecificHeaderField()
            => GetString("Http2ErrorConnectionSpecificHeaderField");

        /// <summary>
        /// Unable to configure default https bindings because no IDefaultHttpsProvider service was provided.
        /// </summary>
        internal static string UnableToConfigureHttpsBindings
        {
            get => GetString("UnableToConfigureHttpsBindings");
        }

        /// <summary>
        /// Unable to configure default https bindings because no IDefaultHttpsProvider service was provided.
        /// </summary>
        internal static string FormatUnableToConfigureHttpsBindings()
            => GetString("UnableToConfigureHttpsBindings");

        /// <summary>
        /// Failed to authenticate HTTPS connection.
        /// </summary>
        internal static string AuthenticationFailed
        {
            get => GetString("AuthenticationFailed");
        }

        /// <summary>
        /// Failed to authenticate HTTPS connection.
        /// </summary>
        internal static string FormatAuthenticationFailed()
            => GetString("AuthenticationFailed");

        /// <summary>
        /// Authentication of the HTTPS connection timed out.
        /// </summary>
        internal static string AuthenticationTimedOut
        {
            get => GetString("AuthenticationTimedOut");
        }

        /// <summary>
        /// Authentication of the HTTPS connection timed out.
        /// </summary>
        internal static string FormatAuthenticationTimedOut()
            => GetString("AuthenticationTimedOut");

        /// <summary>
        /// Certificate {thumbprint} cannot be used as an SSL server certificate. It has an Extended Key Usage extension but the usages do not include Server Authentication (OID 1.3.6.1.5.5.7.3.1).
        /// </summary>
        internal static string InvalidServerCertificateEku
        {
            get => GetString("InvalidServerCertificateEku");
        }

        /// <summary>
        /// Certificate {thumbprint} cannot be used as an SSL server certificate. It has an Extended Key Usage extension but the usages do not include Server Authentication (OID 1.3.6.1.5.5.7.3.1).
        /// </summary>
        internal static string FormatInvalidServerCertificateEku(object thumbprint)
            => string.Format(CultureInfo.CurrentCulture, GetString("InvalidServerCertificateEku", "thumbprint"), thumbprint);

        /// <summary>
        /// Value must be a positive TimeSpan.
        /// </summary>
        internal static string PositiveTimeSpanRequired1
        {
            get => GetString("PositiveTimeSpanRequired1");
        }

        /// <summary>
        /// Value must be a positive TimeSpan.
        /// </summary>
        internal static string FormatPositiveTimeSpanRequired1()
            => GetString("PositiveTimeSpanRequired1");

        /// <summary>
        /// The server certificate parameter is required.
        /// </summary>
        internal static string ServerCertificateRequired
        {
            get => GetString("ServerCertificateRequired");
        }

        /// <summary>
        /// The server certificate parameter is required.
        /// </summary>
        internal static string FormatServerCertificateRequired()
            => GetString("ServerCertificateRequired");

        /// <summary>
        /// No listening endpoints were configured. Binding to {address0} and {address1} by default.
        /// </summary>
        internal static string BindingToDefaultAddresses
        {
            get => GetString("BindingToDefaultAddresses");
        }

        /// <summary>
        /// No listening endpoints were configured. Binding to {address0} and {address1} by default.
        /// </summary>
        internal static string FormatBindingToDefaultAddresses(object address0, object address1)
            => string.Format(CultureInfo.CurrentCulture, GetString("BindingToDefaultAddresses", "address0", "address1"), address0, address1);

        /// <summary>
        /// The requested certificate {subject} could not be found in {storeLocation}/{storeName} with AllowInvalid setting: {allowInvalid}.
        /// </summary>
        internal static string CertNotFoundInStore
        {
            get => GetString("CertNotFoundInStore");
        }

        /// <summary>
        /// The requested certificate {subject} could not be found in {storeLocation}/{storeName} with AllowInvalid setting: {allowInvalid}.
        /// </summary>
        internal static string FormatCertNotFoundInStore(object subject, object storeLocation, object storeName, object allowInvalid)
            => string.Format(CultureInfo.CurrentCulture, GetString("CertNotFoundInStore", "subject", "storeLocation", "storeName", "allowInvalid"), subject, storeLocation, storeName, allowInvalid);

        /// <summary>
        /// The endpoint {endpointName} is missing the required 'Url' parameter.
        /// </summary>
        internal static string EndpointMissingUrl
        {
            get => GetString("EndpointMissingUrl");
        }

        /// <summary>
        /// The endpoint {endpointName} is missing the required 'Url' parameter.
        /// </summary>
        internal static string FormatEndpointMissingUrl(object endpointName)
            => string.Format(CultureInfo.CurrentCulture, GetString("EndpointMissingUrl", "endpointName"), endpointName);

        /// <summary>
        /// Unable to configure HTTPS endpoint. No server certificate was specified, and the default developer certificate could not be found.
        /// To generate a developer certificate run 'dotnet dev-certs https'. To trust the certificate (Windows and macOS only) run 'dotnet dev-certs https --trust'.
        /// For more information on configuring HTTPS see https://go.microsoft.com/fwlink/?linkid=848054.
        /// </summary>
        internal static string NoCertSpecifiedNoDevelopmentCertificateFound
        {
            get => GetString("NoCertSpecifiedNoDevelopmentCertificateFound");
        }

        /// <summary>
        /// Unable to configure HTTPS endpoint. No server certificate was specified, and the default developer certificate could not be found.
        /// To generate a developer certificate run 'dotnet dev-certs https'. To trust the certificate (Windows and macOS only) run 'dotnet dev-certs https --trust'.
        /// For more information on configuring HTTPS see https://go.microsoft.com/fwlink/?linkid=848054.
        /// </summary>
        internal static string FormatNoCertSpecifiedNoDevelopmentCertificateFound()
            => GetString("NoCertSpecifiedNoDevelopmentCertificateFound");

        /// <summary>
        /// The endpoint {endpointName} specified multiple certificate sources.
        /// </summary>
        internal static string MultipleCertificateSources
        {
            get => GetString("MultipleCertificateSources");
        }

        /// <summary>
        /// The endpoint {endpointName} specified multiple certificate sources.
        /// </summary>
        internal static string FormatMultipleCertificateSources(object endpointName)
            => string.Format(CultureInfo.CurrentCulture, GetString("MultipleCertificateSources", "endpointName"), endpointName);

        /// <summary>
        /// Cannot write to the response body, the response has completed.
        /// </summary>
        internal static string WritingToResponseBodyAfterResponseCompleted
        {
            get => GetString("WritingToResponseBodyAfterResponseCompleted");
        }

        /// <summary>
        /// Cannot write to the response body, the response has completed.
        /// </summary>
        internal static string FormatWritingToResponseBodyAfterResponseCompleted()
            => GetString("WritingToResponseBodyAfterResponseCompleted");

        /// <summary>
        /// Reading the request body timed out due to data arriving too slowly. See MinRequestBodyDataRate.
        /// </summary>
        internal static string BadRequest_RequestBodyTimeout
        {
            get => GetString("BadRequest_RequestBodyTimeout");
        }

        /// <summary>
        /// Reading the request body timed out due to data arriving too slowly. See MinRequestBodyDataRate.
        /// </summary>
        internal static string FormatBadRequest_RequestBodyTimeout()
            => GetString("BadRequest_RequestBodyTimeout");

        /// <summary>
        /// The connection was aborted by the application.
        /// </summary>
        internal static string ConnectionAbortedByApplication
        {
            get => GetString("ConnectionAbortedByApplication");
        }

        /// <summary>
        /// The connection was aborted by the application.
        /// </summary>
        internal static string FormatConnectionAbortedByApplication()
            => GetString("ConnectionAbortedByApplication");

        /// <summary>
        /// The connection was aborted because the server is shutting down and request processing didn't complete within the time specified by HostOptions.ShutdownTimeout.
        /// </summary>
        internal static string ConnectionAbortedDuringServerShutdown
        {
            get => GetString("ConnectionAbortedDuringServerShutdown");
        }

        /// <summary>
        /// The connection was aborted because the server is shutting down and request processing didn't complete within the time specified by HostOptions.ShutdownTimeout.
        /// </summary>
        internal static string FormatConnectionAbortedDuringServerShutdown()
            => GetString("ConnectionAbortedDuringServerShutdown");

        /// <summary>
        /// The connection was timed out by the server because the response was not read by the client at the specified minimum data rate.
        /// </summary>
        internal static string ConnectionTimedBecauseResponseMininumDataRateNotSatisfied
        {
            get => GetString("ConnectionTimedBecauseResponseMininumDataRateNotSatisfied");
        }

        /// <summary>
        /// The connection was timed out by the server because the response was not read by the client at the specified minimum data rate.
        /// </summary>
        internal static string FormatConnectionTimedBecauseResponseMininumDataRateNotSatisfied()
            => GetString("ConnectionTimedBecauseResponseMininumDataRateNotSatisfied");

        /// <summary>
        /// The connection was timed out by the server.
        /// </summary>
        internal static string ConnectionTimedOutByServer
        {
            get => GetString("ConnectionTimedOutByServer");
        }

        /// <summary>
        /// The connection was timed out by the server.
        /// </summary>
        internal static string FormatConnectionTimedOutByServer()
            => GetString("ConnectionTimedOutByServer");

        /// <summary>
        /// The received frame size of {size} exceeds the limit {limit}.
        /// </summary>
        internal static string Http2ErrorFrameOverLimit
        {
            get => GetString("Http2ErrorFrameOverLimit");
        }

        /// <summary>
        /// The received frame size of {size} exceeds the limit {limit}.
        /// </summary>
        internal static string FormatHttp2ErrorFrameOverLimit(object size, object limit)
            => string.Format(CultureInfo.CurrentCulture, GetString("Http2ErrorFrameOverLimit", "size", "limit"), size, limit);

        /// <summary>
        /// Tls 1.2 or later must be used for HTTP/2. {protocol} was negotiated.
        /// </summary>
        internal static string Http2ErrorMinTlsVersion
        {
            get => GetString("Http2ErrorMinTlsVersion");
        }

        /// <summary>
        /// Tls 1.2 or later must be used for HTTP/2. {protocol} was negotiated.
        /// </summary>
        internal static string FormatHttp2ErrorMinTlsVersion(object protocol)
            => string.Format(CultureInfo.CurrentCulture, GetString("Http2ErrorMinTlsVersion", "protocol"), protocol);

        /// <summary>
        /// Invalid HTTP/2 connection preface.
        /// </summary>
        internal static string Http2ErrorInvalidPreface
        {
            get => GetString("Http2ErrorInvalidPreface");
        }

        /// <summary>
        /// Invalid HTTP/2 connection preface.
        /// </summary>
        internal static string FormatHttp2ErrorInvalidPreface()
            => GetString("Http2ErrorInvalidPreface");

        /// <summary>
        /// Header name cannot be a null or empty string.
        /// </summary>
        internal static string InvalidEmptyHeaderName
        {
            get => GetString("InvalidEmptyHeaderName");
        }

        /// <summary>
        /// Header name cannot be a null or empty string.
        /// </summary>
        internal static string FormatInvalidEmptyHeaderName()
            => GetString("InvalidEmptyHeaderName");

        /// <summary>
        /// The connection or stream was aborted because a write operation was aborted with a CancellationToken.
        /// </summary>
        internal static string ConnectionOrStreamAbortedByCancellationToken
        {
            get => GetString("ConnectionOrStreamAbortedByCancellationToken");
        }

        /// <summary>
        /// The connection or stream was aborted because a write operation was aborted with a CancellationToken.
        /// </summary>
        internal static string FormatConnectionOrStreamAbortedByCancellationToken()
            => GetString("ConnectionOrStreamAbortedByCancellationToken");

        /// <summary>
        /// The client sent a SETTINGS frame with a SETTINGS_INITIAL_WINDOW_SIZE that caused a flow-control window to exceed the maximum size.
        /// </summary>
        internal static string Http2ErrorInitialWindowSizeInvalid
        {
            get => GetString("Http2ErrorInitialWindowSizeInvalid");
        }

        /// <summary>
        /// The client sent a SETTINGS frame with a SETTINGS_INITIAL_WINDOW_SIZE that caused a flow-control window to exceed the maximum size.
        /// </summary>
        internal static string FormatHttp2ErrorInitialWindowSizeInvalid()
            => GetString("Http2ErrorInitialWindowSizeInvalid");

        /// <summary>
        /// The client sent a WINDOW_UPDATE frame that caused a flow-control window to exceed the maximum size.
        /// </summary>
        internal static string Http2ErrorWindowUpdateSizeInvalid
        {
            get => GetString("Http2ErrorWindowUpdateSizeInvalid");
        }

        /// <summary>
        /// The client sent a WINDOW_UPDATE frame that caused a flow-control window to exceed the maximum size.
        /// </summary>
        internal static string FormatHttp2ErrorWindowUpdateSizeInvalid()
            => GetString("Http2ErrorWindowUpdateSizeInvalid");

        /// <summary>
        /// The HTTP/2 connection faulted.
        /// </summary>
        internal static string Http2ConnectionFaulted
        {
            get => GetString("Http2ConnectionFaulted");
        }

        /// <summary>
        /// The HTTP/2 connection faulted.
        /// </summary>
        internal static string FormatHttp2ConnectionFaulted()
            => GetString("Http2ConnectionFaulted");

        /// <summary>
        /// The client reset the request stream.
        /// </summary>
        internal static string Http2StreamResetByClient
        {
            get => GetString("Http2StreamResetByClient");
        }

        /// <summary>
        /// The client reset the request stream.
        /// </summary>
        internal static string FormatHttp2StreamResetByClient()
            => GetString("Http2StreamResetByClient");

        /// <summary>
        /// The request stream was aborted.
        /// </summary>
        internal static string Http2StreamAborted
        {
            get => GetString("Http2StreamAborted");
        }

        /// <summary>
        /// The request stream was aborted.
        /// </summary>
        internal static string FormatHttp2StreamAborted()
            => GetString("Http2StreamAborted");

        /// <summary>
        /// The client sent more data than what was available in the flow-control window.
        /// </summary>
        internal static string Http2ErrorFlowControlWindowExceeded
        {
            get => GetString("Http2ErrorFlowControlWindowExceeded");
        }

        /// <summary>
        /// The client sent more data than what was available in the flow-control window.
        /// </summary>
        internal static string FormatHttp2ErrorFlowControlWindowExceeded()
            => GetString("Http2ErrorFlowControlWindowExceeded");

        /// <summary>
        /// CONNECT requests must not send :scheme or :path headers.
        /// </summary>
        internal static string Http2ErrorConnectMustNotSendSchemeOrPath
        {
            get => GetString("Http2ErrorConnectMustNotSendSchemeOrPath");
        }

        /// <summary>
        /// CONNECT requests must not send :scheme or :path headers.
        /// </summary>
        internal static string FormatHttp2ErrorConnectMustNotSendSchemeOrPath()
            => GetString("Http2ErrorConnectMustNotSendSchemeOrPath");

        /// <summary>
        /// The Method '{method}' is invalid.
        /// </summary>
        internal static string Http2ErrorMethodInvalid
        {
            get => GetString("Http2ErrorMethodInvalid");
        }

        /// <summary>
        /// The Method '{method}' is invalid.
        /// </summary>
        internal static string FormatHttp2ErrorMethodInvalid(object method)
            => string.Format(CultureInfo.CurrentCulture, GetString("Http2ErrorMethodInvalid", "method"), method);

        /// <summary>
        /// The request :path is invalid: '{path}'
        /// </summary>
        internal static string Http2StreamErrorPathInvalid
        {
            get => GetString("Http2StreamErrorPathInvalid");
        }

        /// <summary>
        /// The request :path is invalid: '{path}'
        /// </summary>
        internal static string FormatHttp2StreamErrorPathInvalid(object path)
            => string.Format(CultureInfo.CurrentCulture, GetString("Http2StreamErrorPathInvalid", "path"), path);

        /// <summary>
        /// The request :scheme header '{requestScheme}' does not match the transport scheme '{transportScheme}'.
        /// </summary>
        internal static string Http2StreamErrorSchemeMismatch
        {
            get => GetString("Http2StreamErrorSchemeMismatch");
        }

        /// <summary>
        /// The request :scheme header '{requestScheme}' does not match the transport scheme '{transportScheme}'.
        /// </summary>
        internal static string FormatHttp2StreamErrorSchemeMismatch(object requestScheme, object transportScheme)
            => string.Format(CultureInfo.CurrentCulture, GetString("Http2StreamErrorSchemeMismatch", "requestScheme", "transportScheme"), requestScheme, transportScheme);

        /// <summary>
        /// Less data received than specified in the Content-Length header.
        /// </summary>
        internal static string Http2StreamErrorLessDataThanLength
        {
            get => GetString("Http2StreamErrorLessDataThanLength");
        }

        /// <summary>
        /// Less data received than specified in the Content-Length header.
        /// </summary>
        internal static string FormatHttp2StreamErrorLessDataThanLength()
            => GetString("Http2StreamErrorLessDataThanLength");

        /// <summary>
        /// More data received than specified in the Content-Length header.
        /// </summary>
        internal static string Http2StreamErrorMoreDataThanLength
        {
            get => GetString("Http2StreamErrorMoreDataThanLength");
        }

        /// <summary>
        /// More data received than specified in the Content-Length header.
        /// </summary>
        internal static string FormatHttp2StreamErrorMoreDataThanLength()
            => GetString("Http2StreamErrorMoreDataThanLength");

        /// <summary>
        /// An error occurred after the response headers were sent, a reset is being sent.
        /// </summary>
        internal static string Http2StreamErrorAfterHeaders
        {
            get => GetString("Http2StreamErrorAfterHeaders");
        }

        /// <summary>
        /// An error occurred after the response headers were sent, a reset is being sent.
        /// </summary>
        internal static string FormatHttp2StreamErrorAfterHeaders()
            => GetString("Http2StreamErrorAfterHeaders");

        /// <summary>
        /// A new stream was refused because this connection has reached its stream limit.
        /// </summary>
        internal static string Http2ErrorMaxStreams
        {
            get => GetString("Http2ErrorMaxStreams");
        }

        /// <summary>
        /// A new stream was refused because this connection has reached its stream limit.
        /// </summary>
        internal static string FormatHttp2ErrorMaxStreams()
            => GetString("Http2ErrorMaxStreams");

        /// <summary>
        /// A value greater than zero is required.
        /// </summary>
        internal static string GreaterThanZeroRequired
        {
            get => GetString("GreaterThanZeroRequired");
        }

        /// <summary>
        /// A value greater than zero is required.
        /// </summary>
        internal static string FormatGreaterThanZeroRequired()
            => GetString("GreaterThanZeroRequired");

        /// <summary>
        /// A value between {min} and {max} is required.
        /// </summary>
        internal static string ArgumentOutOfRange
        {
            get => GetString("ArgumentOutOfRange");
        }

        /// <summary>
        /// A value between {min} and {max} is required.
        /// </summary>
        internal static string FormatArgumentOutOfRange(object min, object max)
            => string.Format(CultureInfo.CurrentCulture, GetString("ArgumentOutOfRange", "min", "max"), min, max);

        /// <summary>
        /// Dynamic tables size update did not occur at the beginning of the first header block.
        /// </summary>
        internal static string HPackErrorDynamicTableSizeUpdateNotAtBeginningOfHeaderBlock
        {
            get => GetString("HPackErrorDynamicTableSizeUpdateNotAtBeginningOfHeaderBlock");
        }

        /// <summary>
        /// Dynamic tables size update did not occur at the beginning of the first header block.
        /// </summary>
        internal static string FormatHPackErrorDynamicTableSizeUpdateNotAtBeginningOfHeaderBlock()
            => GetString("HPackErrorDynamicTableSizeUpdateNotAtBeginningOfHeaderBlock");

        /// <summary>
        /// The given buffer was too small to encode any headers.
        /// </summary>
        internal static string HPackErrorNotEnoughBuffer
        {
            get => GetString("HPackErrorNotEnoughBuffer");
        }

        /// <summary>
        /// The given buffer was too small to encode any headers.
        /// </summary>
        internal static string FormatHPackErrorNotEnoughBuffer()
            => GetString("HPackErrorNotEnoughBuffer");

        /// <summary>
        /// The decoded integer exceeds the maximum value of Int32.MaxValue.
        /// </summary>
        internal static string HPackErrorIntegerTooBig
        {
            get => GetString("HPackErrorIntegerTooBig");
        }

        /// <summary>
        /// The decoded integer exceeds the maximum value of Int32.MaxValue.
        /// </summary>
        internal static string FormatHPackErrorIntegerTooBig()
            => GetString("HPackErrorIntegerTooBig");

        /// <summary>
        /// The client closed the connection.
        /// </summary>
        internal static string ConnectionAbortedByClient
        {
            get => GetString("ConnectionAbortedByClient");
        }

        /// <summary>
        /// The client closed the connection.
        /// </summary>
        internal static string FormatConnectionAbortedByClient()
            => GetString("ConnectionAbortedByClient");

        /// <summary>
        /// A frame of type {frameType} was received after stream {streamId} was reset or aborted.
        /// </summary>
        internal static string Http2ErrorStreamAborted
        {
            get => GetString("Http2ErrorStreamAborted");
        }

        /// <summary>
        /// A frame of type {frameType} was received after stream {streamId} was reset or aborted.
        /// </summary>
        internal static string FormatHttp2ErrorStreamAborted(object frameType, object streamId)
            => string.Format(CultureInfo.CurrentCulture, GetString("Http2ErrorStreamAborted", "frameType", "streamId"), frameType, streamId);

        private static string GetString(string name, params string[] formatterNames)
        {
#pragma warning disable CS0162
            return "fake";

            var value = _resourceManager.GetString(name);
#pragma warning restore CS0162
            System.Diagnostics.Debug.Assert(value != null);

            if (formatterNames != null)
            {
                for (var i = 0; i < formatterNames.Length; i++)
                {
                    value = value.Replace("{" + formatterNames[i] + "}", "{" + i + "}");
                }
            }

            return value;
        }
    }
}
