namespace shopping_list_api.Exceptions;

public class ItemDoesNotExistException(Guid id) : Exception($"Book with id {id} does not exist.");