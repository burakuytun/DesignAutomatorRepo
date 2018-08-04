//requiredroles
//1 normal user
//2 dna manager
//3 system admin

const Home = {
  text: 'Home',
  link: '/home',
  icon: 'icon-home'
};

const Dashboard = {
  text: 'Dashbord',
  link: '/dashboard/v1',
  //icon: 'icon-speedometer',
  image: './assets/fonts/_800_migration_to_hardware_sheet.svg'

};

const DnaManagement = {
  text: 'DNA Management',
  link: '/dna',
  icon: 'icon-doc',
  requiredRoles: [2],
  submenu: [
    {
      text: 'DNA Manager',
      link: '/dna/dnamanager'
    },
    {
      text: 'Add DNA',
      link: '/dna/adddna'
    },
    {
      text: 'Modify DNA',
      link: '/dna/modifydna'
    },
    {
      text: 'DNA Administration',
      link: '/dna/dnaadministration'
    },
    {
      text: 'DNA Product Manager',
      link: '/dna/dnaproductmanager'
    },
    {
      text: 'Select Default DNA',
      link: '/dna/selectdefaultdna'
    }
  ]
};

const Administration = {
  text: 'Administration',
  link: '/dna',
  icon: 'icon-doc',
  requiredRoles: [3],
  submenu: [
    {
      text: 'User Admin',
      link: '/administration/useradministration'
    }
  ]
};

const CadFunctions = {
  text: 'CAD Functions',
  link: '/dna',
  icon: 'icon-doc',
  submenu: [
    {
      text: 'Cad Error Check',
      link: '/sharedfunctions/errorcheck/1'
    },
    {
      text: 'Component Count',
      link: '/sharedfunctions/componentcount/1'
    },
    {
      text: 'Cable Estimation',
      link: '/sharedfunctions/cableestimation/1'
    },
    {
      text: 'Estimating Tools',
      link: '/sharedfunctions/estimatingtools/1'
    },
    {
      text: 'Input Sheet Data',
      link: '/cad/inputsheetdata'
    },
    {
      text: 'Output Sheet Data',
      link: '/cad/outputsheetdata'
    },
    {
      text: 'Output Tag Data',
      link: '/cad/outputtagdata'
    }
  ]
};

const AacsFunctions = {
  text: 'AACS Functions',
  link: '/dna',
  icon: 'icon-doc',
  submenu: [
    {
      text: 'AACS Error Check',
      link: '/sharedfunctions/errorcheck/2'
    },
    {
      text: 'Hardware Sheet',
      link: '/sharedfunctions/hardwaresheet/2'
    },
    {
      text: 'Revision Tracker',
      link: '/sharedfunctions/revisiontracker/2'
    },
    {
      text: 'Door Wizard',
      link: '/aacs/doorwizard'
    },
    {
      text: 'Bill of Quantities',
      link: '/sharedfunctions/estimatingtools/2'
    },
    {
      text: 'Component Count',
      link: '/sharedfunctions/componentcount/2'
    },
    {
      text: 'Cable Estimation',
      link: '/sharedfunctions/cableestimation/2'
    },
    {
      text: 'Commissioning Sheets',
      link: '/sharedfunctions/commissioningsheets/2'
    },
    {
      text: 'Schematics',
      link: '/sharedfunctions/schematics/2'
    },
    {
      text: 'Hardware O & M Manual',
      link: '/sharedfunctions/hardwareoandm/2'
    },
    {
      text: 'System Configuration Files',
      link: '/sharedfunctions/systemconfigurationfiles/2'
    },
    {
      text: 'Reverse Automator',
      link: '/aacs/reverseautomator'
    },
    {
      text: 'Clearance Importer',
      link: '/aacs/clearanceimporter'
    },
    {
      text: 'System Conversion To Hardware Sheet',
      link: '/aacs/systemconversiontohardwaresheet'
    },
    {
      text: '800 Update Migrator',
      link: '/aacs/eighthundredupdatemigrator',
      image: './assets/fonts/_800_migration_to_hardware_sheet.svg'
    }
  ]
};

const CctvFunctions = {
  text: 'CCTV Functions',
  link: '/dna',
  icon: 'icon-doc',
  submenu: [
    {
      icon: 'icon-doc',
      text: 'CCTV Error Check',
      link: '/sharedfunctions/errorcheck/3'
    },
    {
      text: 'Hardware Sheet',
      link: '/sharedfunctions/hardwaresheet/3'
    },
    {
      text: 'Revision Tracker',
      link: '/sharedfunctions/revisiontracker/3'
    },
    {
      text: 'Bill of Quantities',
      link: '/sharedfunctions/estimatingtools/3'
    },
    {
      text: 'Cable Estimation',
      link: '/sharedfunctions/cableestimation/3'
    },
    {
      text: 'Commissioning Sheets',
      link: '/sharedfunctions/commissioningsheets/3'
    },
    {
      text: 'Schematics',
      link: '/sharedfunctions/schematics/3'
    },
    {
      text: 'Hardware O & M Manual',
      link: '/sharedfunctions/hardwareoandm/3'
    },
    {
      text: 'System Configuration Files',
      link: '/sharedfunctions/systemconfigurationfiles/3'
    }
  ]
};

const IhasFunctions = {
  text: 'IHAS Functions',
  link: '/dna',
  icon: 'icon-doc',
  submenu: [
    {
      icon: 'icon-doc',
      text: 'IHAS Error Check',
      link: '/sharedfunctions/errorcheck/4'
    },
    {
      text: 'Hardware Sheet',
      link: '/sharedfunctions/hardwaresheet/4'
    },
    {
      text: 'Revision Tracker',
      link: '/sharedfunctions/revisiontracker/4'
    },
    {
      text: 'Bill of Quantities',
      link: '/sharedfunctions/estimatingtools/4'
    },
    {
      text: 'Cable Estimation',
      link: '/sharedfunctions/cableestimation/4'
    },
    {
      text: 'Commissioning Sheets',
      link: '/sharedfunctions/commissioningsheets/4'
    },
    {
      text: 'Schematics',
      link: '/sharedfunctions/schematics/4'
    },
    {
      text: 'Hardware O & M Manual',
      link: '/sharedfunctions/hardwareoandm/4'
    }
  ]
};

const headingMain = {
  text: 'User Navigation',
  heading: true
};

const headingDnaManagement = {
  text: 'DNA Operations',
  heading: true,
  requiredRoles: [2],
};

const headingFunctions = {
  text: 'Functions',
  heading: true
};

const headingAdmin = {
  text: 'Admin',
  heading: true,
  requiredRoles: [3]
};

const headingHelp = {
  text: 'Help',
  heading: true
};

const helpFunctions = {
  text: 'Help and Support',
  link: '/help',
  icon: 'icon-doc',
  submenu: [
    {
      text: 'Faq',
      link: '/help/faq'
    },
    {
      text: 'Help center',
      link: '/help/helpcenter'
    },
    {
      text: 'Search',
      link: '/help/search'
    },
    {
      text: 'Page Content',
      link: '/help/pagecontent'
    },
    {
      text: 'Page Content Admin',
      link: '/help/pagecontentadmin'
    },
    {
      text: 'Faq Admin',
      link: '/help/faqadmin'
    }
  ]
}

export const menu = [
  headingMain,
  Home,
  Dashboard,
  headingAdmin,
  Administration,
  headingDnaManagement,
  DnaManagement,
  headingFunctions,
  CadFunctions,
  AacsFunctions,
  CctvFunctions,
  IhasFunctions,
  headingHelp,
  helpFunctions
];
