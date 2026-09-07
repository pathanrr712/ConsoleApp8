import { Component, signal } from '@angular/core';
import { Comp1Component } from './comp1/comp1';
import { Comp2Component } from './comp2/comp2';

@Component({
  selector: 'app-root',
  imports: [Comp1Component, Comp2Component],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('angular-ui-claude-ai-integration');
  protected readonly activeTab = signal<'comp1' | 'comp2'>('comp1');

  selectTab(tab: 'comp1' | 'comp2'): void {
    this.activeTab.set(tab);
  }
}
