namespace E2E.Core.Interfaces.ResponseValidators
{
    using System.Net;

    public interface ICommonResponseValidator
    {
        void ValidateErrorCode(int expectedCode);

        void ValidateErrorDescription(string expectedDescription);

        void ValidateHttpStatusCode(HttpStatusCode expectedHttpCode);
    }
}
