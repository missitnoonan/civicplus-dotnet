export function useFormatDate(dateString) {
    const date = new Date(dateString);

    // return date.toLocaleString('default')
    return date.toLocaleString('en-US', {
        month: 'long',
        day: 'numeric',
        year: 'numeric',
        hour: '2-digit',
        minute:'2-digit',
    });
}