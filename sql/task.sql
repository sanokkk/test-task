CREATE TABLE products
(
    id    UNIQUEIDENTIFIER DEFAULT NEWID(),
    title text
);

CREATE TABLE categories
(
    id    UNIQUEIDENTIFIER DEFAULT NEWID() primary key,
    title text
);

CREATE TABLE product_category
(
    id          UNIQUEIDENTIFIER DEFAULT NEWID() primary key,
    product_id  UNIQUEIDENTIFIER,
    category_id UNIQUEIDENTIFIER,
    FOREIGN KEY (product_id) references products (id) on delete cascade,
    foreign key (category_id) references categories (id) on delete cascade
);