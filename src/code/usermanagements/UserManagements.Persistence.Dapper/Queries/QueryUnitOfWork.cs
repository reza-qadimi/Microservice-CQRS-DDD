namespace UserManagements.Persistence.Dapper.Queries;

public abstract class QueryUnitOfWork : object, IQueryUnitOfWork
{
	public QueryUnitOfWork(Framework.Persistence.Tools.Options options) : base()
	{
		Options = options;
	}

	public bool IsDisposed { get; protected set; }

	private System.Data.IDbConnection _databaseConnection;

	internal System.Data.IDbConnection DatabaseConnection
	{
		get
		{
			if (_databaseConnection == null)
			{
				switch (Options.Provider)
				{
					case Framework.Persistence.Tools.Enumerations.Provider.SqlServer:
					{
						_databaseConnection =
							new
							Microsoft.Data.SqlClient.SqlConnection
							(connectionString: Options.ConnectionString);

						break;
					}
				}

				//_databaseConnection.Open();
			}

			return _databaseConnection;
		}
	}

	protected Framework.Persistence.Tools.Options Options { get; }

	public void Dispose()
	{
		Dispose(true);

		System.GC.SuppressFinalize(obj: this);
	}

	public virtual void Dispose(bool disposing)
	{
		if (IsDisposed)
		{
			return;
		}

		if (disposing)
		{
			if (_databaseConnection != null)
			{
				_databaseConnection.Dispose();

				_databaseConnection = null;
			}
		}

		IsDisposed = true;
	}

	~QueryUnitOfWork()
	{
		Dispose(false);
	}
}
