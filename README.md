


# Data Importer

Jednoduchý C# program pro import dat z CSV souborů do SQL Server databáze.

## Instalace

Pro instalaci a spuštění projektu postupujte podle následujících kroků:

1. **Klonování repozitáře**: Klonujte tento repozitář pomocí `git clone` nebo stáhněte zdrojový kód jako ZIP archiv a rozbalte ho.

2. **Otevření projektu**: Otevřete soubor řešení (.sln) ve Visual Studio.

3. **Obnovení NuGet balíčků**: Ujistěte se, že jsou všechny potřebné NuGet balíčky nainstalovány a aktualizované. To zahrnuje `System.Data.SqlClient` a `CsvHelper`.

4. **Vytvoření databáze**: Spusťte přiložený SQL skript v SQL Server Management Studio nebo jiném preferovaném nástroji pro vytvoření databáze a tabulek.

5. **Konfigurace připojovacího řetězce**: Upravte soubor `App.config` ve vašem projektu, abyste nastavili správný připojovací řetězec k vaší databázi.

6. **Spuštění aplikace**: Spusťte aplikaci v Visual Studio nebo zkompilujte a spusťte vytvořený .exe soubor.

## Použití

- Před spuštěním programu upravte cesty k CSV souborům v `Main` třídě pro načtení vašich dat.
- Spusťte aplikaci, která provede import dat a ukáže základní operace definované ve třídě `Main`.


## Autoři

- Tomáš Dvořák




