import { handleRouting } from './router.js';

window.addEventListener('hashchange', () => handleRouting(location.hash));
window.addEventListener('DOMContentLoaded', () => handleRouting(location.hash));