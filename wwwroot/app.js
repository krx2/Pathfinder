document.addEventListener('DOMContentLoaded', () => {
    const walkingDistanceInput = document.getElementById('walkingDistance');
    const distanceValue = document.getElementById('distanceValue');
    const form = document.getElementById('preferences-form');
    
    // UI Elements
    const generateBtn = document.getElementById('generate-btn');
    const loadingScreen = document.getElementById('loading');
    const resultsScreen = document.getElementById('results');
    const attractionsList = document.getElementById('attractions-list');
    
    // Update distance value display
    walkingDistanceInput.addEventListener('input', (e) => {
        distanceValue.textContent = `${e.target.value} km`;
    });

    form.addEventListener('submit', async (e) => {
        e.preventDefault();

        // Gather preferences
        const preferences = {
            walkingDistanceKm: parseFloat(document.getElementById('walkingDistance').value),
            transportMode: document.getElementById('transportMode').value,
            weather: document.getElementById('weather').value,
            focusType: parseInt(document.getElementById('focusType').value)
        };

        // Show loading state, hide form and results
        form.classList.add('hidden');
        resultsScreen.classList.add('hidden');
        loadingScreen.classList.remove('hidden');

        try {
            const response = await fetch('/api/route', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(preferences)
            });

            if (!response.ok) {
                throw new Error('API Error');
            }

            const data = await response.json();
            
            // Artificial delay to show off loading animation
            setTimeout(() => {
                displayResults(data);
            }, 800);

        } catch (error) {
            console.error('Failed to fetch route', error);
            alert('Wystąpił błąd podczas generowania trasy. Spróbuj ponownie później.');
            // Reset UI
            loadingScreen.classList.add('hidden');
            form.classList.remove('hidden');
        }
    });

    function displayResults(data) {
        loadingScreen.classList.add('hidden');
        resultsScreen.classList.remove('hidden');

        document.getElementById('res-distance').textContent = `${data.totalDistanceKm.toFixed(1)} km`;
        
        // Format time properly
        const hours = Math.floor(data.totalEstimatedTimeMinutes / 60);
        const minutes = data.totalEstimatedTimeMinutes % 60;
        let timeStr = '';
        if (hours > 0) timeStr += `${hours}h `;
        timeStr += `${minutes}min`;
        
        document.getElementById('res-time').textContent = timeStr;

        // Render timeline
        attractionsList.innerHTML = '';
        
        if (!data.attractions || data.attractions.length === 0) {
            attractionsList.innerHTML = '<li><p>Niestety, nie znaleźliśmy atrakcji pasujących do Twoich wymagań.</p></li>';
            return;
        }

        data.attractions.forEach((attr, idx) => {
            const li = document.createElement('li');
            li.style.animation = `fadeIn 0.5s ease-out ${idx * 0.15}s both`;
            
            const typeEmoji = attr.isOutdoor ? '🌳' : '🏛️';
            
            li.innerHTML = `
                <h3>${idx + 1}. ${attr.name} ${typeEmoji}</h3>
                <p>
                    <span>Czas spędzony: ${attr.recommendedDurationMinutes} min</span>
                </p>
            `;
            attractionsList.appendChild(li);
        });

        // Add a "Start Over" button at the bottom
        const startOverBtn = document.createElement('button');
        startOverBtn.className = 'primary-btn';
        startOverBtn.style.marginTop = '2rem';
        startOverBtn.style.background = 'rgba(255,255,255,0.1)';
        startOverBtn.style.boxShadow = 'none';
        startOverBtn.textContent = 'Zaplanuj Nową Trasę 🔄';
        startOverBtn.onclick = () => {
            resultsScreen.classList.add('hidden');
            form.classList.remove('hidden');
            // reset form button animation
            form.style.animation = 'none';
            form.offsetHeight; /* trigger reflow */
            form.style.animation = null; 
        };
        attractionsList.appendChild(startOverBtn);
    }
});
