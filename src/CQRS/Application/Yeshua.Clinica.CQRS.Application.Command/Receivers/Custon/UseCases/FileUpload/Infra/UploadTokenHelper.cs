namespace Command.Receivers.Custon.UseCases.FileUpload.Infra;

public sealed class UploadTokenHelper(string signingKey)
    : Command.Patterns.FileUpload.UploadTokenHelper(signingKey);
