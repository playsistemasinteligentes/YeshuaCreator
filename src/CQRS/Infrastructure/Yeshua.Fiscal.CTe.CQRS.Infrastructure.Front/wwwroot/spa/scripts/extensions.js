export function runCrudExtension(hookName, payload = {}) {
    const root = window.yeshuaExtensions;
    const crud = root?.crud || root;
    const hook = crud?.[hookName];

    if (typeof hook !== 'function') return undefined;

    try {
        return hook(payload);
    } catch (error) {
        console.error(`Yeshua CRUD extension failed: ${hookName}`, error);
        return undefined;
    }
}
