using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Common.Errors
{
    public class ErrorService: IErrorService
    {
        private readonly List<Error> _errors;
            //= new List<Error>();
        //{
        //    new Error { ErrorCode = 1, HttpStatusCode = HttpStatusCode.InternalServerError, StatusCode = 500, ErrorMessage = "Unexpected error.",
        //        Scope = "All", Description = "Represents an error that doesn't fall into any other category."},
        //    new Error { ErrorCode = 107, HttpStatusCode = HttpStatusCode.InternalServerError, StatusCode = 500, ErrorMessage = "General database error.",
        //        Scope = "All", Description = "A problem occurred while working with the database. The error message will contain more information about the error."},
        //    new Error { ErrorCode = 107, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "The operation results in a duplicate key for a unique index.",
        //        Scope = "Create", Description = "You are trying to create an item with a field that requires a unique value (for example: \"Id\"). The error shows that an item with such value already exists."},
        //    new Error { ErrorCode = 107, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "Duplicate values already exist for field Number of content type \"New\".",
        //        Scope = "Update field", Description = "You are trying to enforce a uniqueness constraint on the values of a field but the field already contains non-unique values."},
        //    new Error { ErrorCode = 201, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "A user with the same username already exists.",
        //        Scope = "Register user, Update user", Description = "The name of the user account you are creating or updating already exists."},
        //    new Error { ErrorCode = 202, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "No password was specified.",
        //        Scope = "Register user", Description = "You are trying to register a user without specifying a password."},
        //    new Error { ErrorCode = 203, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "No username was specified.",
        //        Scope = "Register user", Description = "You are trying to register a user without specifying a username."},
        //    new Error { ErrorCode = 204, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "The password you specified is not a valid password literal.",
        //        Scope = "Register user, Change password", Description = "The specified password is not in the correct format."},
        //    new Error { ErrorCode = 205, HttpStatusCode = HttpStatusCode.Forbidden, StatusCode = 403, ErrorMessage = "Invalid username or password.",
        //        Scope = "Login", Description = "A user with the specified username and password combination does not exist in the system."},
        //    new Error { ErrorCode = 206, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "The specified user was not found.",
        //        Scope = "Change password, Set password, Reset password", Description = "The specified user was not found."},
        //    new Error { ErrorCode = 207, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "The specified user data is invalid.",
        //        Scope = "Register user, Update user", Description = "Some of the data you specified when creating or updating a user is invalid. The error message will contain specific information about the invalid data."},
        //    new Error { ErrorCode = 208, HttpStatusCode = HttpStatusCode.Forbidden, StatusCode = 403, ErrorMessage = "The specified reset code is invalid.",
        //        Scope = "Set password", Description = "The reset code that you passed is incorrect or has expired."},
        //    new Error { ErrorCode = 209, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "The specified verification code is invalid.",
        //        Scope = "Verify user", Description = "The verification code that you passed is incorrect or has expired."},
        //    new Error { ErrorCode = 210, HttpStatusCode = HttpStatusCode.Forbidden, StatusCode = 403, ErrorMessage = "The specified user is already verified.",
        //        Scope = "Verify user", Description = "You are attempting to verify a user account that has already been verified."},
        //    new Error { ErrorCode = 211, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "A user with the specified email already exists.",
        //        Scope = "Register user, Link user", Description = "You are attempting to use an email address that already exist in the system."},
        //    new Error { ErrorCode = 213, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "The specified user has no email address defined.",
        //        Scope = "Change password, Set password, Reset password, Register user, Resend verification", Description = "The requested operation requires an email address to be set for the user."},
        //    new Error { ErrorCode = 214, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "The specified identity provider is not supported.",
        //        Scope = "Register user, Link user, AD FS metadata", Description = "You have specified an identity provider value that is not recognized by the system."},
        //    new Error { ErrorCode = 215, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "No token was specified.",
        //        Scope = "Register user, Link user", Description = "The provider-generated user access token is not present in the request."},
        //    new Error { ErrorCode = 216, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "No identity provider was specified.",
        //        Scope = "Register user, Link user", Description = "You have not specified an identity provider."},
        //    new Error { ErrorCode = 217, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "Cannot retrieve a user for the specified token.",
        //        Scope = "Register user, Link user", Description = "The system is unable to match the token you specified with a valid user for the identity provider you are using."},
        //    new Error { ErrorCode = 218, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "The user is already linked with the specified provider.",
        //        Scope = "Link user", Description = "The user has already been linked to the specified authentication provider."},
        //    new Error { ErrorCode = 219, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "The user cannot be unlinked because she is not linked with the specified provider.",
        //        Scope = "Unlink user", Description = "You are attempting to remove an authentication provider link that does not exist."},
        //    new Error { ErrorCode = 220, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "The user cannot be unlinked.",
        //        Scope = "Unlink user", Description = "The user cannot be unlinked because it has a single identity provider."},
        //    new Error { ErrorCode = 221, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "The operation is not supported for the given user.",
        //        Scope = "Reset password, Resend verification email", Description = "Reset password and resend verification email are not available for users coming from external identity providers."},
        //    new Error { ErrorCode = 222, HttpStatusCode = HttpStatusCode.Forbidden, StatusCode = 403, ErrorMessage = "The account quota is limited for this operation.",
        //        Scope = "All", Description = "Your subscription plan does not allow you to run the operation. The message will vary based on the operation you are trying to perform."},
        //    new Error { ErrorCode = 223, HttpStatusCode = HttpStatusCode.Forbidden, StatusCode = 403, ErrorMessage = "The account is disabled.",
        //        Scope = "All", Description = "The account that hosts the application has been disabled."},
        //    new Error { ErrorCode = 224, HttpStatusCode = HttpStatusCode.Forbidden, StatusCode = 403, ErrorMessage = "The feature is not enabled for this account.",
        //        Scope = "All", Description = "The experimental feature you are trying to use is not enabled for your account."},
        //    new Error { ErrorCode = 301, HttpStatusCode = HttpStatusCode.Forbidden, StatusCode = 403, ErrorMessage = "Invalid access token.",
        //        Scope = "All", Description = "The provided access token is not valid."},
        //    new Error { ErrorCode = 302, HttpStatusCode = HttpStatusCode.Forbidden, StatusCode = 403, ErrorMessage = "Your access token has expired.",
        //        Scope = "All", Description = "The validity of the provided access token has expired."},
        //    new Error { ErrorCode = 600, HttpStatusCode = HttpStatusCode.NotFound, StatusCode = 404, ErrorMessage = "Not found.",
        //        Scope = "All", Description = "The requested resource was not found."},
        //    new Error { ErrorCode = 601, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "Invalid request.",
        //        Scope = "All", Description = "The request is invalid. Consult the accompanying error message to find out what went wrong."},
        //    new Error { ErrorCode = 602, HttpStatusCode = HttpStatusCode.MethodNotAllowed, StatusCode = 405, ErrorMessage = "Method not supported.",
        //        Scope = "N/A", Description = "You cannot use this HTTP method with this resource."},
        //    new Error { ErrorCode = 603, HttpStatusCode = HttpStatusCode.Forbidden, StatusCode = 403, ErrorMessage = "Access denied.",
        //        Scope = "All", Description = "You are not allowed to perform the operation."},
        //    new Error { ErrorCode = 604, HttpStatusCode = HttpStatusCode.Unauthorized, StatusCode = 401, ErrorMessage = "Unauthorized.",
        //        Scope = "All", Description = "You did not provide authorization which is required for this operation."},
        //    new Error { ErrorCode = 605, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "Missing or invalid API version.",
        //        Scope = "N/A", Description = "The API version is missing from the request URL."},
        //    new Error { ErrorCode = 606, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "Missing App ID.",
        //        Scope = "N/A", Description = "The App ID is missing from the request URL."},
        //    new Error { ErrorCode = 607, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "Invalid App ID.",
        //        Scope = "N/A", Description = "The specified App ID is invalid. Make sure you are using the correct App ID."},
        //    new Error { ErrorCode = 608, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "Invalid filter expression.",
        //        Scope = "Read, Delete, Update", Description = "The filter expression you specified is invalid. Make sure the filter expression is a valid JSON object and it is in the required format."},
        //    new Error { ErrorCode = 609, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "Invalid sort expression.",
        //        Scope = "Read", Description = "The sort expression you specified is invalid. Make sure the sort expression is a valid JSON object and it is in the required format."},
        //    new Error { ErrorCode = 610, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "Missing or invalid content type. Please specify a valid Content-Type header.",
        //        Scope = "All", Description = "The Content-Type header is required for this operation, but is either missing or invalid."},
        //    new Error { ErrorCode = 611, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "The specified content type was not found.",
        //        Scope = "All data operations*, Metadata operations† for content types", Description = "You specified an unexisting content type."},
        //    new Error { ErrorCode = 612, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "Invalid power fields definition.",
        //        Scope = "Read", Description = "The Power Fields definition you specified is invalid. Make sure the Power Fields definition is a valid JSON object and it is in the required format."},
        //    new Error { ErrorCode = 613, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "Unsupported Content-Type.",
        //        Scope = "Set cloud code", Description = "The specified content type is not supported by this request."},
        //    new Error { ErrorCode = 614, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "Invalid custom parameter expression.",
        //        Scope = "All data operations*", Description = "The custom parameters expression you specified is invalid. Make sure it is a valid JSON object."},
        //    new Error { ErrorCode = 615, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "Invalid request body.",
        //        Scope = "All", Description = "The body of the HTTP request is invalid. Make sure its format is consistent with the Content-Type header you specified."},
        //    new Error { ErrorCode = 616, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "Invalid fields expression.",
        //        Scope = "Read", Description = "The fields expression you specified is invalid. Make sure the fields expression is a valid JSON and it is in the required format."},
        //    new Error { ErrorCode = 617, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "Loop detected.",
        //        Scope = "All data operations*", Description = "An infinite loop was detected. This usually happens when your cloud code makes a call that results in the execution of the same code."},
        //    new Error { ErrorCode = 618, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "Invalid expand expression.",
        //        Scope = "Read operations", Description = "The expand expression you specified is invalid. Make sure the expand expression is in the required format."},
        //    new Error { ErrorCode = 619, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "Invalid single field expression.",
        //        Scope = "Read operations", Description = "The single field expression you specified is invalid. Make sure the single field expression is a non-empty string."},
        //    new Error { ErrorCode = 630, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "Invalid metadata definition specified.",
        //        Scope = "Metadata operations†", Description = "The metadata request contains or results in an invalid metadata definition. Refer to the accompanying error message to find out what went wrong."},
        //    new Error { ErrorCode = 640, HttpStatusCode = HttpStatusCode.NotAcceptable, StatusCode = 406, ErrorMessage = "The specified response content type is not supported.",
        //        Scope = "All", Description = "The response content type you specified in the request is not supported."},
        //    new Error { ErrorCode = 650, HttpStatusCode = HttpStatusCode.RequestTimeout, StatusCode = 408, ErrorMessage = "The request timed out.",
        //        Scope = "All", Description = "The request timed out. A request times out if it does not complete in specified interval."},
        //    new Error { ErrorCode = 660, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "Data Link Server Error",
        //        Scope = "All", Description = "The Data Link Server returned an error. Refer to the accompanying error message to find out what went wrong."},
        //    new Error { ErrorCode = 670, HttpStatusCode = HttpStatusCode.ServiceUnavailable, StatusCode = 503, ErrorMessage = "Application is down for maintenance",
        //        Scope = "All", Description = "The application is down for maintenance. You are advised to stop all requests to it and resume them at a later time."},
        //    new Error { ErrorCode = 701, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "ContentType not specified.",
        //        Scope = "Upload file (base64)", Description = "The required ContentType parameter is not specified."},
        //    new Error { ErrorCode = 702, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "Missing or invalid file content.",
        //        Scope = "Upload file, Update file content, Set cloud code", Description = "You have not specified file content or the specified file content is invalid."},
        //    new Error { ErrorCode = 801, HttpStatusCode = HttpStatusCode.NotFound, StatusCode = 404, ErrorMessage = "Item not found.",
        //        Scope = "Read by ID, Delete by ID, Update by ID", Description = "The specified item was not found."},
        //    new Error { ErrorCode = 901, HttpStatusCode = HttpStatusCode.InternalServerError, StatusCode = 500, ErrorMessage = "An error occurred during execution of custom server code.",
        //        Scope = "All data operations*, Execute cloud function", Description = "There was an error while executing your cloud code. Review your cloud code logic."},
        //    new Error { ErrorCode = 902, HttpStatusCode = HttpStatusCode.InternalServerError, StatusCode = 500, ErrorMessage = "The execution of the custom server code timed out.",
        //        Scope = "All data operations*, Execute cloud function", Description = "The execution of your custom code took too long. Make sure you properly call the \"done\" callback in all cases."},
        //    new Error { ErrorCode = 910, HttpStatusCode = HttpStatusCode.InternalServerError, StatusCode = 500, ErrorMessage = "The request was canceled by custom server code.",
        //        Scope = "All data operations*", Description = "Your custom cloud code canceled the operation."},
        //    new Error { ErrorCode = 951, HttpStatusCode = HttpStatusCode.InternalServerError, StatusCode = 500, ErrorMessage = "The custom code definition failed to compile.",
        //        Scope = "All data operations*", Description = "The cloud code for the operation failed to compile. Check your cloud code for typos and syntax errors."},
        //    new Error { ErrorCode = 955, HttpStatusCode = HttpStatusCode.InternalServerError, StatusCode = 500, ErrorMessage = "Custom cloud code is disabled for this type.",
        //        Scope = "All data operations*", Description = "The cloud code for this content type have been disabled due to too many timeouts. Contact Support for more information."},
        //    new Error { ErrorCode = 960, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "The request was processed but an error was generated by custom code.",
        //        Scope = "All data operations*", Description = "If you don't include your own error code when you are setting an error in your cloud code, then this default code is automatically added."},
        //    new Error { ErrorCode = 1000, HttpStatusCode = HttpStatusCode.BadRequest, StatusCode = 400, ErrorMessage = "Error processing email template.",
        //        Scope = "Send email", Description = "There was an error processing the email template. The message may contain more information about the error."},
        //};

        public ErrorService()
        {
            _errors = DeserializeFromXml<List<Error>>("Resources/Errors.xml");
        }

        private void SerializeToXml<T>(T value, string path)
        {
            using (var writer = new XmlTextWriter(path, Encoding.UTF8))
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(writer, value);
            }
        }

        private T DeserializeFromXml<T>(string path)
        {
            using (var reader = new XmlTextReader(path))
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                return (T)xmlSerializer.Deserialize(reader);
            }
        }

        public Error GetError(ErrorType errorType)
        {
            return GetError((short) errorType);
        }

        public Error GetError(short id)
        {
            return _errors.Single(e => e.Id == id);
        }
    }
}
