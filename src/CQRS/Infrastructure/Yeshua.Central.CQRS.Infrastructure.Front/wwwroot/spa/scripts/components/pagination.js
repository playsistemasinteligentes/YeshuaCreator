export function createPaginationState({ page = 1, pageSize = 10, pageWhithCount = false } = {}) {
    return {
        page,
        pageSize,
        pageWhithCount,
        totalItems: 0,
        totalPages: 1,
        hasNext: false
    };
}

export function buildPaginationRequest(pagination, page = pagination.page) {
    return {
        page: Math.max(1, Number(page) || 1),
        pageSize: Math.max(1, Number(pagination.pageSize) || 10),
        pageWhithCount: pagination.pageWhithCount !== false
    };
}

export function readPaginatedResult(result, fallbackPagination) {
    const source = result?.data || result?.Data || result?.retorno || result?.Retorno || result || {};
    const items = readItems(source);
    const page = Number(readField(source, 'page', 'Page')) || Number(fallbackPagination.page) || 1;
    const pageSize = Number(readField(source, 'pageSize', 'PageSize')) || Number(fallbackPagination.pageSize) || Math.max(1, items.length);
    const totalItems = Number(readField(source, 'totalItems', 'TotalItems')) || 0;
    const totalPages = totalItems > 0
        ? Math.max(1, Math.ceil(totalItems / pageSize))
        : Math.max(1, Number(fallbackPagination.totalPages) || page);
    const hasNext = totalItems > 0
        ? page * pageSize < totalItems
        : items.length === pageSize;

    return {
        items,
        page,
        pageSize,
        totalItems,
        totalPages,
        hasNext
    };
}

export function applyPaginationResult(pagination, result) {
    pagination.page = result.page;
    pagination.pageSize = result.pageSize;
    pagination.totalItems = result.totalItems;
    pagination.totalPages = result.totalPages;
    pagination.hasNext = result.hasNext;
}

export function paginationStatusText(pagination, itemCount) {
    if (pagination.totalItems > 0) {
        const start = ((pagination.page - 1) * pagination.pageSize) + 1;
        const end = Math.min(start + itemCount - 1, pagination.totalItems);
        return `pagina ${pagination.page} | exibindo ${start} a ${end} de ${pagination.totalItems}`;
    }

    return `pagina ${pagination.page} | ${itemCount} caso(s)`;
}

function readField(object, ...names) {
    if (!object) return undefined;

    for (const name of names) {
        if (Object.prototype.hasOwnProperty.call(object, name)) {
            return object[name];
        }
    }

    return undefined;
}

function readItems(source) {
    if (Array.isArray(source)) {
        return source;
    }

    const items = readField(source, 'items', 'Items', 'itens', 'Itens', 'results', 'Results');
    return Array.isArray(items) ? items : [];
}
