import { handleRouting } from './router.js?v=20260920-operational01';
import { initFkModal } from './components/fk-modal.js';
import './pages/operational-control.js?v=20260920-operational01';

window.addEventListener('DOMContentLoaded', async () => {
    await initFkModal(); // carrega o modal uma �nica vez
    handleRouting(location.hash);
});

window.addEventListener('hashchange', () => {
    handleRouting(location.hash);
});
