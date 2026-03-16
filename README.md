# Pathfinder - Asystent Planowania Wycieczek 🗺️

Pathfinder to aplikacja demonstracyjna w technologii .NET 9 Web API używająca czystego HTML/CSS/JS (zainspirowanego Glassmorphism), która układa optymalną trasę turystyczną po wybranych atrakcjach (np. Warszawie) dopasowując ją do indywidualnych wymagań użytkownika (dostępny czas, chęć spacerowania vs transport miejski, preferencje pogody, eksploracja vs relaks).

## 🚀 Jak Uruchomić Aplikację

Ponieważ frontend i backend współdzielą ten sam serwer (zawartość folderu `wwwroot` jest serwowana bezpośrednio z backendem w potoku ASP.NET), jedyne co musisz zrobić to podnieść API:

1. Upewnij się, że masz zainstalowany **.NET 9 SDK**.
2. Otwórz konsolę / terminal i przejdź do katalogu projektu `Pathfinder`.
3. Uruchom serwer komendą:
   ```bash
   dotnet run
   ```
4. Aplikacja udostępni port lokalnie (domyślnie `http://localhost:5233` dla profilu HTTP z `launchSettings.json`). Możesz go odczytać z konsoli po uruchomieniu aplikacji.
5. Otwórz adres uruchomionego serwera w przeglądarce, np. `http://localhost:5233/index.html` lub po prostu `http://localhost:5233`, aby przetestować planowanie w wizualnym i stylowym konfiguratorze!

## 🧪 Browser Tests (Subagent Testujący)

Aplikacja przeszła testy za pomocą zaawansowanego agenta AI (Subagenta Przeglądarkowego). 

Subagent przeglądarkowy działa w następujący sposób:
1. **Powołanie Agenta:** Tworzony jest jednorazowy agent posiadający narzędzia wyłącznie do analizy DOM i kontrolowania przeglądarki.
2. **Nawigacja:** Agent ładuje interfejs pod wskazanym adresem (`http://localhost:5233`). Ogląda kod źródłowy DOM w poszukiwaniu przycisków i pól do interakcji.
3. **Podejmowanie Akcji:** Za pomocą precyzyjnych koordynatów klika elementy nałożone na interfejs. W przypadku tej aplikacji:
   - Symulował wybór **środka transportu** poprzez zlokalizowanie elementu `<select>` HTML i zasymulowanie na niego kliknięć.
   - Pociągnął (Drag&Drop) domyślny **suwak (range slider)** by zmienić wyjściowe kilometry do limitu dla przejścia z 5km na 17km.
   - Odnalazł przycisk `Generuj Plan 🚀` i zasymulował "lewy-klik" myszką (wykonując przy tym wizualne zrzuty "przed i po").
4. **Odczyt Wyników:** Po stronie serwerowej wyliczony został Nearest Neighbor API. Agent zaczekał, po czym sprawdził odpowiedź asynchroniczną JS "fetch()". Odczytał widoczne sekcje (Wyniki w formacie `Szacowany Czas: 6h 13min`). Zapisał wynik testu, aby poinformować o przejściu testu end-to-end, podając screenshoty wyświelające udany design interfejsu.
