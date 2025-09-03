import { describe, it, expect } from 'vitest'

import { mount } from '@vue/test-utils'
import EventListCard from "@/components/Events/EventListCard.vue";

const titleText = 'Test Title';
const descriptionText = 'Test Description is a little longer';
const event = {
    id: 'test-id-123',
    title: titleText,
    description: descriptionText,
    startDate: '2030-04-30T10:00:00Z',
    endDate: '2030-05-02T10:00:00Z',
}

describe('Event List Card', () => {
    it('it displays and formats event properly for list view', () => {
        const wrapper = mount(EventListCard, {
            propsData: {
                event: event,
                showDetails: false,
            }
        });

        const title = wrapper.find('[data-testid="title"]');
        expect(title.text()).toBe(titleText);

        const description = wrapper.find('[data-testid="description"]');
        expect(description.exists()).toBe(false);

        const link = wrapper.find('[data-testid="link"]');
        expect(link.exists()).toBe(true);
        expect(link).toBeDefined();
    });

    it('it displays and formats event properly for details view', () => {
        const titleText = 'Test Title';
        const descriptionText = 'Test Description is a little longer';

        const wrapper = mount(EventListCard, {
            propsData: {
                event: event,
                showDetails: true,
            }
        });

        const title = wrapper.find('[data-testid="title"]');
        expect(title.text()).toBe(titleText);

        const description = wrapper.find('[data-testid="description"]');
        expect(description.text()).toBe(descriptionText);

        const link = wrapper.find('[data-testid="link"]');
        expect(link.exists()).toBe(false);
    });
});