import { Component } from '@angular/core';
import { DashboardService } from '../../../core/services/dashboard.service';
import { MatCardModule } from '@angular/material/card';
import { CommonModule } from '@angular/common';
import { MatIcon } from '@angular/material/icon';
import { MatPaginatorModule } from '@angular/material/paginator';
import { GoogleChartsModule } from 'angular-google-charts';
import { MatTableModule } from '@angular/material/table';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatMenuModule } from '@angular/material/menu';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    MatIcon,
    MatTableModule,
    MatPaginatorModule,
    GoogleChartsModule,
    MatProgressSpinnerModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatInputModule,
    MatMenuModule,
    MatButtonModule,
    ReactiveFormsModule
  ],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent {
  summary: any;
  demographics: any;
  recentClients: any[] = [];
  loading = true;

  // Chart options
  genderChart: any;
  policyChart: any;

  constructor(private dashboardService: DashboardService) { }

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    this.dashboardService.getSummary().subscribe({
      next: (data) => {
        this.summary = data;
        this.setupCharts();
      },
      error: (err) => console.error(err)
    });

    this.dashboardService.getDemographics().subscribe({
      next: (data) => this.demographics = data,
      error: (err) => console.error(err)
    });

    this.dashboardService.getRecentClients().subscribe({
      next: (data) => this.recentClients = data,
      error: (err) => console.error(err),
      complete: () => this.loading = false
    });
  }

  private setupCharts() {
    this.genderChart = {
      title: 'Client Gender Distribution',
      type: 'PieChart',
      data: [
        ['Male', this.demographics.genderDistribution.male],
        ['Female', this.demographics.genderDistribution.female]
      ],
      columnNames: ['Gender', 'Count'],
      options: {
        is3D: true,
        pieHole: 0.4
      }
    };

    this.policyChart = {
      title: 'Policy Status Distribution',
      type: 'ColumnChart',
      data: this.summary.policyStatusDistribution,
      columnNames: ['Status', 'Count'],
      options: {
        hAxis: { title: 'Status' },
        vAxis: { title: 'Count' },
        legend: 'none'
      }
    };
  }

}
