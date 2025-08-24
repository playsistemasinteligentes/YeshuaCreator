import { handleRouting } from './router.js';
import { initFkModal } from './components/fk-modal.js';

window.addEventListener('DOMContentLoaded', async () => {
    await initFkModal(); // carrega o modal uma única vez
    handleRouting(location.hash);
});

window.addEventListener('hashchange', () => {
    handleRouting(location.hash);
});
