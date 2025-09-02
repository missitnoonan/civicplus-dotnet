class EventApiProvider {
    constructor() {
        this.baseApi = import.meta.env.VITE_EVENT_BASE_URL;
    }

    async getEventList(page = 1) {
        const options = {
            method: 'GET',
            mode: 'cors',
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json",
            },
        }

        const skip = (page - 1) * 10 // using the default;
        
        const response = await fetch(this.baseApi + 'events?skip=' + skip, options);
        const json = response?.json();

        // total, array items
        if (json) {
            return json;
        } else {
            // TODO: Add notification system
            console.log('There was a problem I should do something about')

            return null;
        }
    }

    async getEvent(id) {
        const options = {
            method: 'GET',
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json",
            },
        }

        const response = await fetch(this.baseApi + 'events/' + id, options);
        const json = response?.json();

        if (json) {
            return json;
        } else {
            // TODO: Add notification system
            console.log('There was a problem I should do something about')

            return null;
        }
    }

    async postEvent(event) {
        const options = {
            method: 'POST',
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json",
            },
            body: JSON.stringify(event),
        }

        const response = await fetch(this.baseApi + 'events', options);

        if (response.ok) {
            return true;
        }

        return false;
    }
}

export default new EventApiProvider();