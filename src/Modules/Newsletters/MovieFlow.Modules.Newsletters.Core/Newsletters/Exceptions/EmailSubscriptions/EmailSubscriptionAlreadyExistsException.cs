using MovieFlow.Shared.Abstractions.Exceptions;

namespace MovieFlow.Modules.Newsletters.Core.Newsletters.Exceptions.EmailSubscriptions;

internal class EmailSubscriptionAlreadyExistsException(string email) 
    : MovieFlowException($"Subscription with '{email}' already exists.");