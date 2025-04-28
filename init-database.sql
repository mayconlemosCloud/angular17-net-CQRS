INSERT INTO "Products" ("Id", "Name", "UnitPrice") VALUES
    (gen_random_uuid(), 'Product A', 10.00),
    (gen_random_uuid(), 'Product B', 20.00),
    (gen_random_uuid(), 'Product C', 30.00)
ON CONFLICT DO NOTHING;

INSERT INTO "Customers" ("Id", "Name") VALUES
    (gen_random_uuid(), 'Customer 1'),
    (gen_random_uuid(), 'Customer 2'),
    (gen_random_uuid(), 'Customer 3')
ON CONFLICT DO NOTHING;

INSERT INTO "Sales" ("Id", "CreatedAt", "CustomerId", "Branch", "TotalAmount", "Discount", "IsCancelled") VALUES
    (gen_random_uuid(), NOW(), (SELECT "Id" FROM "Customers" LIMIT 1 OFFSET 0), 'Branch A', 100.00, 10.00, FALSE),
    (gen_random_uuid(), NOW(), (SELECT "Id" FROM "Customers" LIMIT 1 OFFSET 1), 'Branch B', 200.00, 20.00, FALSE),
    (gen_random_uuid(), NOW(), (SELECT "Id" FROM "Customers" LIMIT 1 OFFSET 2), 'Branch C', 300.00, 30.00, TRUE)
ON CONFLICT DO NOTHING;

INSERT INTO "SaleItems" ("Id", "SaleId", "ProductId", "Quantity", "UnitPrice") VALUES
    (gen_random_uuid(), (SELECT "Id" FROM "Sales" LIMIT 1 OFFSET 0), (SELECT "Id" FROM "Products" LIMIT 1 OFFSET 0), 2, 10.00),
    (gen_random_uuid(), (SELECT "Id" FROM "Sales" LIMIT 1 OFFSET 1), (SELECT "Id" FROM "Products" LIMIT 1 OFFSET 1), 3, 20.00),
    (gen_random_uuid(), (SELECT "Id" FROM "Sales" LIMIT 1 OFFSET 2), (SELECT "Id" FROM "Products" LIMIT 1 OFFSET 2), 4, 30.00)
ON CONFLICT DO NOTHING;


