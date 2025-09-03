import { describe, it, expect } from 'vitest'

import { mount } from '@vue/test-utils'
import Pagination from "@/components/Pagination.vue";

describe('Pagination', () => {
    it('renders previous and next when on page 2 of 3', () => {
        const wrapper = mount(Pagination, {
            propsData: {
                routeName: 'events',
                currentPage: 2,
                pages: 3
            }
        });
        const previous = wrapper.find('#previous');
        expect(previous.exists()).toBe(true);

        const next = wrapper.find('#next');
        expect(next.exists()).toBe(true);
    });

    it('renders previous when on page 3 of 3', () => {
        const wrapper = mount(Pagination, {
            propsData: {
                routeName: 'events',
                currentPage: 3,
                pages: 3
            }
        });
        const previous = wrapper.find('#previous');
        expect(previous.exists()).toBe(true);

        const next = wrapper.find('#next');
        expect(next.exists()).toBe(false);
    });

    it('renders next when on page 1 of 3', () => {
        const wrapper = mount(Pagination, {
            propsData: {
                routeName: 'events',
                currentPage: 1,
                pages: 3
            }
        });
        const previous = wrapper.find('#previous');
        expect(previous.exists()).toBe(false);

        const next = wrapper.find('#next');
        expect(next.exists()).toBe(true);
    });

    it('emits on click', () => {
        const wrapper = mount(Pagination, {
            propsData: {
                routeName: 'events',
                currentPage: 2,
                pages: 3
            }
        });

        const previous = wrapper.find('#previous');
        previous.trigger('click');

        expect(wrapper.emitted()).toHaveProperty('navigate');
        const navigateEvent = wrapper.emitted('navigate')
        expect(navigateEvent[0]).toEqual([1]);
    });
});