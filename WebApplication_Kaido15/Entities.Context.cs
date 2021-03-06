﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはテンプレートから生成されました。
//
//     このファイルを手動で変更すると、アプリケーションで予期しない動作が発生する可能性があります。
//     このファイルに対する手動の変更は、コードが再生成されると上書きされます。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication_Kaido15
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Student> Student { get; set; }
    
        public virtual int sp_DeleteStudent(Nullable<int> id, ObjectParameter result)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DeleteStudent", idParameter, result);
        }
    
        public virtual ObjectResult<sp_GetStudent_Result> sp_GetStudent(Nullable<int> pageNo, Nullable<int> pageSize)
        {
            var pageNoParameter = pageNo.HasValue ?
                new ObjectParameter("PageNo", pageNo) :
                new ObjectParameter("PageNo", typeof(int));
    
            var pageSizeParameter = pageSize.HasValue ?
                new ObjectParameter("PageSize", pageSize) :
                new ObjectParameter("PageSize", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetStudent_Result>("sp_GetStudent_Result", pageNoParameter, pageSizeParameter);
        }
    
        public virtual ObjectResult<sp_GetStudentById_Result> sp_GetStudentById(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetStudentById_Result>("sp_GetStudentById", idParameter);
        }
    
        public virtual int sp_InsertStudent(string name, string address, Nullable<int> age, string standard, Nullable<decimal> percent, Nullable<bool> status, ObjectParameter result, ObjectParameter createdId)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            var ageParameter = age.HasValue ?
                new ObjectParameter("Age", age) :
                new ObjectParameter("Age", typeof(int));
    
            var standardParameter = standard != null ?
                new ObjectParameter("Standard", standard) :
                new ObjectParameter("Standard", typeof(string));
    
            var percentParameter = percent.HasValue ?
                new ObjectParameter("Percent", percent) :
                new ObjectParameter("Percent", typeof(decimal));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertStudent", nameParameter, addressParameter, ageParameter, standardParameter, percentParameter, statusParameter, result, createdId);
        }
    
        public virtual int sp_UpdateStudent(Nullable<int> id, string name, string address, Nullable<int> age, string standard, Nullable<decimal> percent, Nullable<bool> status, ObjectParameter result)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            var ageParameter = age.HasValue ?
                new ObjectParameter("Age", age) :
                new ObjectParameter("Age", typeof(int));
    
            var standardParameter = standard != null ?
                new ObjectParameter("Standard", standard) :
                new ObjectParameter("Standard", typeof(string));
    
            var percentParameter = percent.HasValue ?
                new ObjectParameter("Percent", percent) :
                new ObjectParameter("Percent", typeof(decimal));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_UpdateStudent", idParameter, nameParameter, addressParameter, ageParameter, standardParameter, percentParameter, statusParameter, result);
        }
    }
}
