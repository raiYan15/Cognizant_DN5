using System;
namespace EmployeeManagementSystem{
    class Employee{
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public Employee(int employeeId, string name, string position, double salary){
            EmployeeId = employeeId;
            Name = name;
            Position = position;
            Salary = salary;
        }
        public override string ToString() =>
            $"{EmployeeId}  {Name,-15}   {Position,-20}   ${Salary:F2}";
    }
    class EmployeeManager{
        private Employee[] employees;
        private int count;
        public EmployeeManager(int capacity){
            employees = new Employee[capacity];
            count = 0;
        }
        public bool AddEmployee(Employee emp){
            if (count >= employees.Length){
                Console.WriteLine("Array is full. Cannot add more employees.");
                return false;
            }
            employees[count++] = emp;
            Console.WriteLine($"Added: {emp}");
            return true;
        }
        public Employee SearchById(int employeeId){
            for (int i = 0; i < count; i++){
                if (employees[i].EmployeeId == employeeId)
                    return employees[i];
            }
            return null;
        }
        public void TraverseAll(){
            if (count == 0) { Console.WriteLine("No employees on record."); return; }
            Console.WriteLine("\nEmployee Records ");
            for (int i = 0; i < count; i++)
                Console.WriteLine(employees[i]);
            Console.WriteLine(" ");
        }
        public bool DeleteEmployee(int employeeId){
            for (int i = 0; i < count; i++){
                if (employees[i].EmployeeId == employeeId){
                    Console.WriteLine($"Deleting: {employees[i]}");                
                    for (int j = i; j < count - 1; j++)
                        employees[j] = employees[j + 1];
                    employees[--count] = null; 
                    return true;
                }
            }
            Console.WriteLine($"Employee ID {employeeId} not found.");
            return false;
        }
    }
    class Program{
        static void Main(string[] args){
            EmployeeManager mgr = new EmployeeManager(10);
            mgr.AddEmployee(new Employee(1, "Arun Kumar",   "Software Engineer", 75000));
            mgr.AddEmployee(new Employee(2, "Priya Singh",  "Team Lead",          95000));
            mgr.AddEmployee(new Employee(3, "Rohan Mehta",  "QA Engineer",        65000));
            mgr.AddEmployee(new Employee(4, "Sneha Patel",  "Business Analyst",   80000));
            mgr.AddEmployee(new Employee(5, "Vikram Reddy", "DevOps Engineer",    88000));
            mgr.TraverseAll();
            Console.WriteLine("\nSearch:  ");
            Employee found = mgr.SearchById(3);
            Console.WriteLine(found != null ? $"Found: {found}" : "Not found.");
            Console.WriteLine("\nDelete: ");
            mgr.DeleteEmployee(2);
            mgr.DeleteEmployee(99); 
            mgr.TraverseAll();
        }
    }
}
