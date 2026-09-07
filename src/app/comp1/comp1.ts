import { Component, inject } from '@angular/core';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-comp1',
  templateUrl: './comp1.html',
  styleUrl: './comp1.scss'
})
export class Comp1Component {
  private readonly sanitizer = inject(DomSanitizer);
  protected readonly safeUrl: SafeResourceUrl = this.sanitizer.bypassSecurityTrustResourceUrl('https://claude.ai');
}
