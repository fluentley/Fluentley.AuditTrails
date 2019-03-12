
# Fluentley Audit Trails
Audit Trails Mechanism for EntityFramework Core

This library heavily influenced a great by [blog post](https://www.meziantou.net/2017/08/14/entity-framework-core-history-audit-table) from **GÉRALD BARRÉ**.

I have attempted to segregate it a bit further.

## Usage
### 1. Setup dependency injection
```csharp
	public void ConfigureServices(IServiceCollection services)
        {

		services.AddAuditTrails(options =>
	           {
	               options.HandleRecordAuditing(auditTrails =>
	               {
	                   //Handle auditing based on your design
	               });
	           });
	        }
```
### 2. Configure DbContext Changes
```csharp
public class DatabaseContext : DbContext
    {
        private readonly AuditTrailService _auditTrailService;
 
        public DatabaseContext(DbContextOptions<DatabaseContext> options, AuditTrailService auditTrailService) : base(options)
        {
            _auditTrailService = auditTrailService;
        }
 
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            return _auditTrailService.SaveChangesAsync(dbContext =>
            {
                return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            });
        }
    }
```
### 3. Using Attributes to determine models to including in auditing
Default auditing behavior is ignored, we will need to specify the models we need to use auditing.

```csharp
	   [Audit] //Includes model to auditing, any properties below are included.
	   public class Customer
	   {
	       public int Id { get; set; }
	       public string Name { get; set; }
	 
	       [Audit(Ignore = true)] // Incase of not disable auditing in property please use ignore.
	       public DateTime CreatedOn { get; set; }
	 
	       [Audit(Ignore = true)]
	       public DateTime? ModifiedOn { get; set; }
	   }
``` 
