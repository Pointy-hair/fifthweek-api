﻿using System;
using System.Linq;



namespace Fifthweek.Api.Persistence.Tests.Shared
{
	using System;
	using System.Linq;
	using System.Data.Entity.Infrastructure;
	using System.Data.Entity.Migrations;
	using System.Diagnostics;
	using Fifthweek.Api.Core;
	using Fifthweek.Api.Persistence.Identity;
	using Fifthweek.Api.Persistence.Migrations;
	using System.Threading.Tasks;
	using System.Collections.Generic;
	using System.Data.Entity;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	public partial class TemporaryDatabase 
	{
        public TemporaryDatabase(
            System.String connectionString)
        {
            if (connectionString == null)
            {
                throw new ArgumentNullException("connectionString");
            }

            this.connectionString = connectionString;
        }
	}

}
namespace Fifthweek.Api.Persistence.Tests.Shared
{
	using System;
	using System.Linq;
	using System.Data.Entity.Infrastructure;
	using System.Data.Entity.Migrations;
	using System.Diagnostics;
	using Fifthweek.Api.Core;
	using Fifthweek.Api.Persistence.Identity;
	using Fifthweek.Api.Persistence.Migrations;
	using System.Threading.Tasks;
	using System.Collections.Generic;
	using System.Data.Entity;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	public partial class TemporaryDatabaseState 
	{
        public TemporaryDatabaseState(
            Fifthweek.Api.Persistence.Tests.Shared.TemporaryDatabase temporaryDatabase)
        {
            if (temporaryDatabase == null)
            {
                throw new ArgumentNullException("temporaryDatabase");
            }

            this.temporaryDatabase = temporaryDatabase;
        }
	}

}
namespace Fifthweek.Api.Persistence.Tests.Shared
{
	using System;
	using System.Linq;
	using System.Data.Entity.Infrastructure;
	using System.Data.Entity.Migrations;
	using System.Diagnostics;
	using Fifthweek.Api.Core;
	using Fifthweek.Api.Persistence.Identity;
	using Fifthweek.Api.Persistence.Migrations;
	using System.Threading.Tasks;
	using System.Collections.Generic;
	using System.Data.Entity;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	public partial class TemporaryDatabaseSeed 
	{
        public TemporaryDatabaseSeed(
            Fifthweek.Api.Persistence.Identity.FifthweekDbContext databaseContext)
        {
            if (databaseContext == null)
            {
                throw new ArgumentNullException("databaseContext");
            }

            this.databaseContext = databaseContext;
        }
	}

}
namespace Fifthweek.Api.Persistence.Tests.Shared
{
	using System;
	using System.Linq;
	using System.Data.Entity.Infrastructure;
	using System.Data.Entity.Migrations;
	using System.Diagnostics;
	using Fifthweek.Api.Core;
	using Fifthweek.Api.Persistence.Identity;
	using Fifthweek.Api.Persistence.Migrations;
	using System.Threading.Tasks;
	using System.Collections.Generic;
	using System.Data.Entity;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	public partial class TableBeforeAndAfter 
	{
        public TableBeforeAndAfter(
            System.Collections.Generic.IReadOnlyList<Fifthweek.Api.Persistence.IIdentityEquatable> snapshot, 
            System.Collections.Generic.IReadOnlyList<Fifthweek.Api.Persistence.IIdentityEquatable> database)
        {
            if (snapshot == null)
            {
                throw new ArgumentNullException("snapshot");
            }

            if (database == null)
            {
                throw new ArgumentNullException("database");
            }

            this.Snapshot = snapshot;
            this.Database = database;
        }
	}

}



