using HashTable;

Table table = new ();
table["Водоросли"] = 280;
table["Картофель"] = 260;
table["Лук-порей"] = 59;
table["Манго"] = 291;
table["Орехи грецкие"] = 266;
table["Салями"] = 225;
table["Специи"] = 283;
table["Сыр сливочный"] = 152;
table["Творог"] = 215;
table["Тофу"] = 142;
table["Хек"] = 248;
table["Чай чёрный"] = 118;
table["Чернила каракатицы"] = 95;
table["Шампиньоны"] = 101;
table["Финик"] = 104;
table.View();

table.Remove("Орехи грецкие");
table.Remove("Водоросли");
table.Remove("Специи");
table.Remove("Манго");

table.View();