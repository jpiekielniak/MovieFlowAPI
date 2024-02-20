using MovieFlow.Shared.Abstractions.Exceptions;

namespace MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Recipient.Exceptions;

internal class InvalidRecipientException(string email) : MovieFlowException($"Recipient email {email} is invalid.");