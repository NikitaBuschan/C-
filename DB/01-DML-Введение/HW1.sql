use Books
go

select *
from Books;

-- 1
select [Name] as [Название] 
from Books
where Izd not like '%BHV%' and Pressrun >= 3000;
--

-- 2
select *
from Books
where Date >= DATEFROMPARTS(1999, 01, 01);
--

-- 3
select *
from Books
where Date is null;
--

-- 4
select *
from Books
where New = 1 and Price <= 30;
--

-- 5
select *
from Books
where Name like '%Microsoft%' and Name not like '%Windows%';
--

-- 6
select *, Pages / Price as CostPerPage
from Books
where (Price <> 0) and (Pages <> 0) and (Price / Pages < 0.10);
--

-- 7
select *
from Books
where Name like '%[0-9]%';
--

-- 8
select *
from Books
where Name like '%[0-9]%[0-9]%[0-9]%';
--

-- 9
select *
from Books
where Name like '%[0-9]%[0-9]%[0-9]%[0-9]%[0-9]%' and 
	  Name not like '%[0-9]%[0-9]%[0-9]%[0-9]%[0-9]%[0-9]%';
--

-- 10
delete
from Books
where Name like '%6%' or Name like '%7%';
--

-- 11
UPDATE Books
set Date = GETDATE()
where Date is null;
--