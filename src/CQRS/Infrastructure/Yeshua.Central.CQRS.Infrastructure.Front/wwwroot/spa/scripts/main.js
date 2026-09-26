import { handleRouting } from './router.js?v=20260926-userarea01';
import { initFkModal } from './components/fk-modal.js';
import { initializeApplicationContext } from './application-context.js';
import './pages/operational-control.js?v=20260920-operational02';

window.addEventListener('DOMContentLoaded', async () => {
    await initializeApplicationContext();
    await initFkModal(); // carrega o modal uma �nica vez
    handleRouting(location.hash);
});

window.addEventListener('hashchange', () => {
    handleRouting(location.hash);
});
