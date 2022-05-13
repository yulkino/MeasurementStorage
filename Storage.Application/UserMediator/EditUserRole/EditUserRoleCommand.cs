namespace Storage.Application.UserMediator.EditUserRole;

public record EditUserRoleCommand(Guid UserId, List<NewRole> Roles) : IOperation;

public enum NewRole { Default, Editor, Admin }
