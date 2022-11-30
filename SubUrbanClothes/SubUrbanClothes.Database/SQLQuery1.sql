use SubUrbanClothesDB

insert into Brands values ('Nike');
insert into Brands values ('Adidas');
insert into Brands values ('Calvin Klein');
insert into Brands values ('Tommy Hilfiger');

insert into Categories values ('Sneakers');
insert into Categories values ('Pants');
insert into Categories values ('TShirts');
insert into Categories values ('Hoodies');
insert into Categories values ('Jackets');

insert into Colors values ('Red');
insert into Colors values ('Green');
insert into Colors values ('Blue');
insert into Colors values ('Purple');
insert into Colors values ('Brown');
insert into Colors values ('Black');
insert into Colors values ('White');

insert into Genders values ('Men');
insert into Genders values ('Women');
insert into Genders values ('Children');

insert into Products values ('Nike Tee', 50, 'L', 'Clothes', 'data:image/jpeg;base64,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', 1, 6, 3, 1)
insert into Products values ('Nike Tee', 50, 'M', 'Clothes', 'https://static.nike.com/a/images/t_PDP_1280_v1/f_auto,q_auto:eco/vgk0u8hhp7n63punqbbt/futura-icon-t-shirt-nnTrAOJn.png', 1, 1, 3, 2)
insert into Products values ('Adidas Hoodie', 70, 'S', 'Clothes', 'https://img01.ztat.net/article/spp-media-p1/6e774e1b996c4a44a2417038ddb8a059/52654c128ff647d0bbd83a591f67ec7c.jpg?imwidth=1800&filter=packshot', 2, 7, 4, 3)