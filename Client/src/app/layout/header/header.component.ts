// header.component.ts
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

interface MenuItem {
  label: string;
  route?: string;
  subItems?: MenuItem[];
}

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {
  mainMenuItems: MenuItem[] = [
    {
      label: 'Clients',
      subItems: [
        { label: 'View Clients', route: '/clients/history' },
        { label: 'Add New Client', route: '/clients/add' },
        { label: 'View Members', route: '/clients/update' }
      ]
    },
    {
      label: 'Burial Plans',
      subItems: [
        { label: 'View Plans', route: '/burial-plans' },
        { label: 'Create New Plan', route: '/burial-plans/create' }
      ]
    },
    {
      label: 'Config',
      subItems: [
        { label: 'Users', route: '/burial-plans' },
      ]
    },
    {
      label: 'Reports',
      subItems: [
        { label: 'Monthly Stats', route: '/burial-plans' },
      ]
    }
  ];

  // Updated icon mapping in header.component.ts
  getSubItemIcon(label: string): string {
    const icons: { [key: string]: string } = {
      'View Clients': 'history_edu',
      'Add New Client': 'person_add_alt',
      'View Members': 'groups',
      'View Plans': 'library_books',
      'Create New Plan': 'note_add'
    };
    return icons[label] || 'arrow_forward';
  }

  selectedMainMenu: MenuItem = this.mainMenuItems[0];

  selectMainMenu(menu: MenuItem): void {
    this.selectedMainMenu = menu;
  }
}