import { handleRouting } from './router.js';

window.addEventListener('DOMContentLoaded', () => {
    handleRouting(location.hash);
});


window.addEventListener('hashchange', () => {
    handleRouting(location.hash);
});
