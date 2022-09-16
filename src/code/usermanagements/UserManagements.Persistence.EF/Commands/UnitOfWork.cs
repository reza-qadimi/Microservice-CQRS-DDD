using Microsoft.EntityFrameworkCore;

namespace UserManagements.Persistence.EF.Commands;

public abstract class UnitOfWork : object, IUnitOfWork
{
	public UnitOfWork(Framework.Persistence.Tools.Options options) : base()
	{
		Options = options;
	}

	public bool IsDisposed { get; protected set; }

	private DatabaseContext _databaseContext;

	internal DatabaseContext DatabaseContext
	{
		get
		{
			if (_databaseContext == null)
			{
				var optionsBuilder =
					new
					Microsoft.EntityFrameworkCore
					.DbContextOptionsBuilder<DatabaseContext>();

				switch (Options.Provider)
				{
					case Framework.Persistence.Tools.Enumerations.Provider.SqlServer:
						{
							optionsBuilder.UseSqlServer
								(connectionString: Options.ConnectionString);

							break;
						}
				}

				_databaseContext =
					new DatabaseContext(options: optionsBuilder.Options);
			}

			return _databaseContext;
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
			if (_databaseContext != null)
			{
				_databaseContext.Dispose();

				_databaseContext = null;
			}
		}

		IsDisposed = true;
	}

	public virtual void Save()
	{
		DatabaseContext.SaveChanges();
	}

	public virtual async
		System.Threading.Tasks.Task
		SaveAsync
		(System.Threading.CancellationToken cancellationToken = default)
	{
		await DatabaseContext.SaveChangesAsync
			(cancellationToken: cancellationToken);
	}

	~UnitOfWork()
	{
		Dispose(false);
	}
}
