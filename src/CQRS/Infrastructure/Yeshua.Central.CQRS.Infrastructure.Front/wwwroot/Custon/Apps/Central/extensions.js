window.yeshuaExtensions = window.yeshuaExtensions || {};
window.yeshuaExtensions.pages = window.yeshuaExtensions.pages || {};

window.yeshuaExtensions.pages['application-catalog'] = async function openApplicationCatalog() {
    const page = await import('/Custon/Apps/Central/pages/application-catalog.js?v=20260924-central01');
    await page.renderApplicationCatalog();
};

window.yeshuaExtensions.dashboard = async function openCentralDashboard() {
    const page = await import('/Custon/Apps/Central/pages/application-catalog.js?v=20260924-central02');
    await page.renderApplicationCatalog();
};
