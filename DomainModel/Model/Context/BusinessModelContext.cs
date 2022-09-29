using Microsoft.EntityFrameworkCore;


namespace DomainModel.Model.Context
{
    public partial class BusinessModelContext : DbContext
    {
        public BusinessModelContext()
        {
        }

        public BusinessModelContext(DbContextOptions<BusinessModelContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Business>(entity =>
            {
                entity.ToTable("Business");

                entity.Property(e => e.BusinessId)
                    .ValueGeneratedNever()
                    .HasColumnName("business_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Ceo>(entity =>
            {
                entity.HasKey(e => e.BusinessId)
                    .HasName("pk_ceo");

                entity.ToTable("Ceo");

                entity.HasIndex(e => e.EmployeeId, "unq_ceo")
                    .IsUnique();

                entity.Property(e => e.BusinessId)
                    .ValueGeneratedNever()
                    .HasColumnName("business_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.HasOne(d => d.Business)
                    .WithOne(p => p.Ceo)
                    .HasForeignKey<Ceo>(d => d.BusinessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ceo_business");

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.Ceo)
                    .HasForeignKey<Ceo>(d => d.EmployeeId)
                    .HasConstraintName("fk_employee");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.HasIndex(e => e.DivisionId, "idx_department");

                entity.Property(e => e.DepartmentId)
                    .ValueGeneratedNever()
                    .HasColumnName("department_id");

                entity.Property(e => e.DivisionId).HasColumnName("division_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Objective)
                    .HasMaxLength(1000)
                    .HasColumnName("objective");

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.DivisionId)
                    .HasConstraintName("fk_department_division");
            });

            modelBuilder.Entity<DepartmentChief>(entity =>
            {
                entity.HasKey(e => e.DepartmentId)
                    .HasName("pk_department_chief");

                entity.ToTable("DepartmentChief");

                entity.HasIndex(e => e.EmployeeId, "unq_department_chief")
                    .IsUnique();

                entity.Property(e => e.DepartmentId)
                    .ValueGeneratedNever()
                    .HasColumnName("department_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.HasOne(d => d.Department)
                    .WithOne(p => p.DepartmentChief)
                    .HasForeignKey<DepartmentChief>(d => d.DepartmentId)
                    .HasConstraintName("fk_department_chief_department");

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.DepartmentChief)
                    .HasForeignKey<DepartmentChief>(d => d.EmployeeId)
                    .HasConstraintName("fk_department_chief_employee");
            });

            modelBuilder.Entity<Director>(entity =>
            {
                entity.HasKey(e => e.DivisionId)
                    .HasName("pk_director");

                entity.ToTable("Director");

                entity.HasIndex(e => e.EmployeeId, "unq_director")
                    .IsUnique();

                entity.Property(e => e.DivisionId)
                    .ValueGeneratedNever()
                    .HasColumnName("division_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.HasOne(d => d.Division)
                    .WithOne(p => p.Director)
                    .HasForeignKey<Director>(d => d.DivisionId)
                    .HasConstraintName("fk_director_division");

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.Director)
                    .HasForeignKey<Director>(d => d.EmployeeId)
                    .HasConstraintName("fk_director_employee");
            });

            modelBuilder.Entity<Division>(entity =>
            {
                entity.ToTable("Division");

                entity.HasIndex(e => e.BusinessId, "idx_division");

                entity.Property(e => e.DivisionId)
                    .ValueGeneratedNever()
                    .HasColumnName("division_id");

                entity.Property(e => e.BusinessId).HasColumnName("business_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Objective)
                    .HasMaxLength(1000)
                    .HasColumnName("objective");

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.Divisions)
                    .HasForeignKey(d => d.BusinessId)
                    .HasConstraintName("fk_division_business");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedNever()
                    .HasColumnName("employee_id");

                entity.Property(e => e.BusinessId).HasColumnName("business_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");

                entity.Property(e => e.Title)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.BusinessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_employee_business");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project");

                entity.HasIndex(e => e.DepartmentId, "idx_project");

                entity.Property(e => e.ProjectId)
                    .ValueGeneratedNever()
                    .HasColumnName("project_id");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .HasColumnName("description");

                entity.Property(e => e.FinishesAt)
                    .HasColumnType("date")
                    .HasColumnName("finishes_at");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(100)
                    .HasColumnName("product_name");

                entity.Property(e => e.StartsAt)
                    .HasColumnType("date")
                    .HasColumnName("starts_at");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("fk_project_department");

                entity.HasMany(d => d.Employees)
                    .WithMany(p => p.Projects)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProjectParticipant",
                        l => l.HasOne<Employee>().WithMany().HasForeignKey("EmployeeId").HasConstraintName("fk_project_participant"),
                        r => r.HasOne<Project>().WithMany().HasForeignKey("ProjectId").HasConstraintName("fk_project_participant_project"),
                        j =>
                        {
                            j.HasKey("ProjectId", "EmployeeId").HasName("pk_project_participant");

                            j.ToTable("ProjectParticipant");

                            j.IndexerProperty<int>("ProjectId").HasColumnName("project_id");

                            j.IndexerProperty<int>("EmployeeId").HasColumnName("employee_id");
                        });
            });

            modelBuilder.Entity<ProjectManager>(entity =>
            {
                entity.HasKey(e => e.ProjectId)
                    .HasName("pk_project_manager");

                entity.ToTable("ProjectManager");

                entity.HasIndex(e => e.EmployeeId, "unq_project_manager")
                    .IsUnique();

                entity.Property(e => e.ProjectId)
                    .ValueGeneratedNever()
                    .HasColumnName("project_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.ProjectManager)
                    .HasForeignKey<ProjectManager>(d => d.EmployeeId)
                    .HasConstraintName("fk_project_manager_employee");

                entity.HasOne(d => d.Project)
                    .WithOne(p => p.ProjectManager)
                    .HasForeignKey<ProjectManager>(d => d.ProjectId)
                    .HasConstraintName("fk_project_manager_project");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
