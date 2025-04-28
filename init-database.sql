CREATE TABLE IF NOT EXISTS "Products" (
    "Id" UUID PRIMARY KEY,
    "Name" VARCHAR(255),
    "UnitPrice" DECIMAL
);

CREATE TABLE IF NOT EXISTS "Customers" (
    "Id" UUID PRIMARY KEY,
    "Name" VARCHAR(255)
);

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