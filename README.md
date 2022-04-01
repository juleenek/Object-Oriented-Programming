
## Zadanie: Kserokopiarka. Implementacje interfejsów, kompozycje

- Krzysztof Molenda, ver. 01/2020.11.10

Dla wszystkich zadań utwórz jedno solution. Projekty nazywaj: Zadanie1, Zadanie2, ... . Będą to projekty typu Console Application.

Podobnie dla projektów typu unit tests, przyjmij nazwy Zadanie1UnitTests, Zadanie2UnitTests, ... .

Zadania wykonuj w podanej kolejności - są zależne od siebie.

Realizując to ćwiczenie, nabędziesz umiejętności modelowania obiektowego, uwzględniającego hierarchie interfejsów i klas, klasy abstrakcyjne, dziedziczenie, implementacje interfejsów (explicit i implicit), ... .

Zastosujesz relacje is-a oraz has-a, wzorzec delegacji, kompozycję zamiast dziedziczenia.

Orientacyjny czas realizacji ćwiczenia: od 60 do 90 minut.

[Zadanie. Implementacje interfejsów (explicit, implicit), kompozycja - Copier](https://github.com/wsei-csharp201/cs-lab04-Implementacje-interfejsow-implicit-explicit-kompozycja)


## Implementacja interfejsów IEquatable, IComparable, IComparer

- Autor: Krzysztof Molenda

[Implementacja interfejsów IEquatable, IComparable, IComparer](https://github.com/wsei-csharp201/cs-lab02-Implementacja-IEquatable-IComparable-IComparer/blob/main/docs/index.md)

## Lab-03. Well formed class - Pudelko

- Autor: Krzysztof Molenda

Współpracujesz w rozwoju systemu wspomagającego obsługę Firmy Kurierskiej i optymalizującego załadunek. Twoim zadaniem jest opracować klasę Pudelko.

Pudełko to prostopadłościan o zadanych długościach krawędzi (umownie: długość, wysokość, szerokość). Wymiary te mogą być podawane w milimetrach, centymetrach bądź metrach - jako wartości rzeczywiste. Cyfry poza zakresem dla określonej jednostki są odcinane (np. dla 2.54637 m przyjmujemy 2.546 m czyli 254.6 cm, czyli 2546 mm)!

- Przyjmujemy, że maksymalny pojedynczy wymiar pudełka nie przekracza 10 metrów (ze względu na ograniczone możliwości załadunkowe).

- Twoim zadaniem jest zaimplementowanie klasy Pudelko spełniającej podane poniżej warunki:

- Obiekty klasy Pudelko są niezmiennicze.

- Domyślnym pudełkiem jest prostopadłościan o krawędziach a, b, c o wymiarach odpowiednio 10 cm × 10 cm × 10 cm.

- Klasa jest zapieczętowana (nie można z niej dziedziczyć).

[Lab-03. Well formed class - Pudelko](https://github.com/wsei-csharp201/cs-lab03-Pudelko)
