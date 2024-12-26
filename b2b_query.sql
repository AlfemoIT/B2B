select *
from Users as usr
inner join CustomerAssignments as customera on customera.UserID = usr.ID 
inner join Customers as customer on customer.ID = customera.CustomerID
