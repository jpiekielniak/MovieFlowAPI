using MovieFlow.Shared.Abstractions.Exceptions;

namespace MovieFlow.Modules.Newsletters.Core.Newsletters.Exceptions.EmailSubscriptions;

internal class EmailSubscriptionNotFoundException(string email) : MovieFlowException($"Subscription with email '{email}' not found.");