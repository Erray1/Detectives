namespace Detectives.Entities.SessionCommands;

public class ModifySessionCommand
{
    public string SessionId { get; set; }
    public ModifySessionCommandType CommandType { get; set; }

}
