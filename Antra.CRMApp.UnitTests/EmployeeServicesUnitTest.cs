using Microsoft.VisualStudio.TestTools.UnitTesting; 
using Antra.CRMApp.Infrastructure.Service;
using Antra.CRMApp.Core.Contract.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using Antra.CRMApp.Core.Entity;
using Moq;
using Antra.CRMApp.Core.Model;
using System.Linq;

namespace Antra.CRMApp.UnitTests
{
    [TestClass]
    public class EmployeeServicesUnitTest
    {
        private EmployeeServiceAsync _sut;
        private static List<Employee> _employees;
        private Mock<IEmployeeRepositoryAsync> _employeeRepository;

        [TestInitialize]
        public void OneTimeSetup() {
            _employeeRepository = new Mock<IEmployeeRepositoryAsync>();
            _sut = new EmployeeServiceAsync(_employeeRepository.Object);
            _employeeRepository.Setup(expression: m => m.GetAllAsync()).ReturnsAsync(_employees); 
        }

        [ClassInitialize]
        public static void SetUp(TestContext context) {
            _employees = new List<Employee>
            {
                new Employee { Id = 1,FirstName="A",LastName="1", },
                new Employee { Id = 2,FirstName="B",LastName="2" },
                new Employee { Id = 3,FirstName="C",LastName="3" },
            }; 
        }

        [TestMethod]
        public async void TestGetAllAsyncFromFakeData()
        {
            // sut system under test
            //Arrange, Act, Assert

            //Arrange  - mock objects, data, methods
            //_sut = new EmployeeServiceAsync(new MockEmployeeRepository());


            //Act
            var employees = await _sut.GetAllAsync();
             

            //Assert
            Assert.IsNotNull(employees);
            Assert.IsInstanceOfType(employees, typeof(IEnumerable<EmployeeResponseModel>));
            Assert.AreEqual(expected: 3, actual: employees.ToList().Count());
        }
    }
}


//public class MockEmployeeRepository : IEmployeeRepositoryAsync
//{
//    public Task<int> DeleteAsync(int id)
//    {
//        throw new System.NotImplementedException();
//    }

//    public async Task<IEnumerable<Employee>> GetAllAsync()
//    {
//        //Test method

//        var employee = new List<Employee> {
//            new Employee { Id = 1, }

//        };
//        return employee; 
//    }

//    public Task<Employee> GetByIdAsync(int id)
//    {
//        throw new System.NotImplementedException();
//    }

//    public Task<IEnumerable<Employee>> GetByNameAsync(string name)
//    {
//        throw new System.NotImplementedException();
//    }

//    public Task<int> InsertAsync(Employee entity)
//    {
//        throw new System.NotImplementedException();
//    }

//    public Task<int> UpdateAsync(Employee entity)
//    {
//        throw new System.NotImplementedException();
//    }
//}
