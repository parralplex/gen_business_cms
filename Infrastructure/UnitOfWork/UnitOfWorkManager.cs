using DomainModel.Model;
using DomainModel.Model.Context;
using Infrastructure.Repository.Abstract;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWorkManager : IUnitOfWork, IDisposable
    {
        private BusinessModelContext BusinessDBContext;
        private GenericRepository<Department> departmentRepository;
        private GenericRepository<Business> businessRepository;
        private GenericRepository<Project> projectRepository;
        private GenericRepository<Division> divisionRepository;
        private GenericRepository<Employee> employeeRepository;
        private GenericRepository<Ceo> ceoRepository;
        private GenericRepository<Director> directorRepository;
        private GenericRepository<ProjectManager> projectManagerRepository;
        private GenericRepository<DepartmentChief> departmentChiefRepository;

        public GenericRepository<DepartmentChief> DepartmentChiefRepository
        {
            get
            {

                if (this.departmentChiefRepository == null)
                {
                    this.departmentChiefRepository = new GenericRepository<DepartmentChief>(BusinessDBContext);
                }
                return departmentChiefRepository;
            }
        }
        public GenericRepository<ProjectManager> ProjectManagerRepository
        {
            get
            {

                if (this.projectManagerRepository == null)
                {
                    this.projectManagerRepository = new GenericRepository<ProjectManager>(BusinessDBContext);
                }
                return projectManagerRepository;
            }
        }
        public GenericRepository<Director> DirectorRepository
        {
            get
            {

                if (this.directorRepository == null)
                {
                    this.directorRepository = new GenericRepository<Director>(BusinessDBContext);
                }
                return directorRepository;
            }
        }

        public GenericRepository<Ceo> CeoRepository
        {
            get
            {

                if (this.ceoRepository == null)
                {
                    this.ceoRepository = new GenericRepository<Ceo>(BusinessDBContext);
                }
                return ceoRepository;
            }
        }

        public GenericRepository<Department> DepartmentRepository
        {
            get
            {

                if (this.departmentRepository == null)
                {
                    this.departmentRepository = new GenericRepository<Department>(BusinessDBContext);
                }
                return departmentRepository;
            }
        }        
        public GenericRepository<Project> ProjectRepository
        {
            get
            {

                if (this.projectRepository == null)
                {
                    this.projectRepository = new GenericRepository<Project>(BusinessDBContext);
                }
                return projectRepository;
            }
        }        
        public GenericRepository<Business> BusinessRepository
        {
            get
            {

                if (this.businessRepository == null)
                {
                    this.businessRepository = new GenericRepository<Business>(BusinessDBContext);
                }
                return businessRepository;
            }
        }        
        public GenericRepository<Division> DivisionRepository
        {
            get
            {

                if (this.divisionRepository == null)
                {
                    this.divisionRepository = new GenericRepository<Division>(BusinessDBContext);
                }
                return divisionRepository;
            }
        }        
        public GenericRepository<Employee> EmployeeRepository
        {
            get
            {

                if (this.employeeRepository == null)
                {
                    this.employeeRepository = new GenericRepository<Employee>(BusinessDBContext);
                }
                return employeeRepository;
            }
        }

        public UnitOfWorkManager(BusinessModelContext pdbContext)
        {
            IsDesposed = false;
            BusinessDBContext = pdbContext;
        }

        public bool IsDesposed { get; private set; }

        public void SaveChanges()
        {
            BusinessDBContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!IsDesposed)
            {
                if (disposing)
                {
                    BusinessDBContext.Dispose();
                }
            }
            IsDesposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
