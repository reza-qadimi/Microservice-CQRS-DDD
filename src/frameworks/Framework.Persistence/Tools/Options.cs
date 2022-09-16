using Framework.Persistence.Tools.Enumerations;

namespace Framework.Persistence.Tools;

public class Options : object
{
	public Options() : base()
	{
	}

	public string? ConnectionString { get; set; }

	public Provider Provider { get; set; }
}
