namespace WebServer.API.Exceptions;

public class PhoneNotFoundException(Guid id) : NotFoundException("Phone", id);