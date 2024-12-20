﻿using Company.BLL.Interfaces;

namespace Company.BLL
{
    public interface IUnitOfwork
    {
        public IEmployeeRepository EmployeeRepository { get; }
        public IDepartmentRespository DepartmentRespository { get; }

        Task<int> CompleteAsync();
    }
}
