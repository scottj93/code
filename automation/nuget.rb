module Automation
  class Nuget < Thor
    namespace :nuget

    TIMESTAMP_KEY = :nuget_packages

    desc 'install', 'installs the required third party libs'
    def install
      nuget("install -OutputDirectory #{packages_folder}")
    end

    desc 'get_latest_version', 'upgrades to the latest version of nuget'
    def get_latest_version
      nuget("update -self")
    end

    desc 'update', 'updates nuget packages'
    def update
      nuget("update")
    end

    desc 'clear', 'clears out all the nuget packages'
    def clear
      FileUtils.rm_rf packages_folder
    end

    desc 'refresh_packages', 'conditionally refreshes nuget packages based on whether changes have been made to source/config/packages.config.settings'
    def refresh_packages
      return unless nuget_packages_changed?

      invoke 'automation:expand'
      invoke :clear
      invoke :install

      invoke 'timestamps:update', [TIMESTAMP_KEY.to_s]
    end

    no_commands do
      def nuget(command)
        base_command = "automation/tools/nuget/nuget"
        full_command = "#{base_command} #{command} #{nuget_config_file}"
        system(full_command)
      end

      def nuget_packages_changed?
        timestamps = ::Automation::Utils::TimeStampSet.load(settings.timestamps.verification_file)

        timestamps.updated?(TIMESTAMP_KEY, *settings.timestamps.bundles.nuget_packages.files)
      end

      def packages_folder
        settings.nuget.packages_folder
      end

      def nuget_config_file
        settings.nuget.packages_config
      end
    end
  end
end
