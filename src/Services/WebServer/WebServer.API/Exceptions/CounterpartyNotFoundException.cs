namespace WebServer.API.Exceptions;

public class CounterpartyNotFoundException(Guid id) : NotFoundException("Counterparty", id);